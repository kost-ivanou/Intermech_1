using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Collections;
using Google.Protobuf.WellKnownTypes;

namespace Winform_4
{
    public class DownloadTask
    {
        private readonly string _filePath;
        private readonly IDbService _db;
        private readonly int _chunkSize = 1 * 1024 * 1024;

        private bool _isPaused;
        private bool _isCanceled;
        public long _uploadedBytes;
        public long _totalBytes;
        private int _fileId = 0;
        private int _retryCount;
        private CancellationTokenSource _cts;

        public event Action<DownloadTask, double> ProgressChanged;
        public event Action<DownloadTask, DownloadTaskStatus, string> StatusChanged;

        public string FileName => Path.GetFileName(_filePath);
        public DownloadTaskStatus Status { get; private set; }

        public DownloadTask(string filePath, IDbService db)
        {
            _filePath = filePath;
            _db = db;
            _totalBytes = new FileInfo(filePath).Length;
            if (_totalBytes > 256 * 1024 * 1024) throw new InvalidOperationException("Размер файла превышает 256 МБ.");
        }

        public async Task StartAsync()
        {
            if(_isCanceled) return;
            _cts = new CancellationTokenSource();
            _isPaused = false;
            _isCanceled = false;
            _retryCount = 0;
            await InitializeFileInDatabaseAsync();
            int maxRetries = 3;

            while (_retryCount < maxRetries)
            {
                try
                {
                    await UploadAsync(_cts.Token);
                    break;
                }
                catch (OperationCanceledException)
                {
                    DownloadTaskStatus cancelStatus = _isPaused ? DownloadTaskStatus.Paused : DownloadTaskStatus.Canceled;
                    UpdateStatus(cancelStatus, cancelStatus.ToFriendlyString());
                    await UpdateStatusInDbAsync(cancelStatus);
                    break;
                }
                catch (Exception ex)
                {
                    _retryCount++;
                    UpdateStatus(DownloadTaskStatus.Error, DownloadTaskStatus.Error.ToFriendlyString(ex.Message));
                    if (_retryCount < maxRetries)
                    {
                        UpdateStatus(DownloadTaskStatus.Retrying, DownloadTaskStatus.Retrying.ToFriendlyString(_retryCount, maxRetries));
                        await Task.Delay(2000);
                    }
                    else
                    {
                        UpdateStatus(DownloadTaskStatus.Error, DownloadTaskStatus.Error.ToFriendlyString());
                        await UpdateStatusInDbAsync(DownloadTaskStatus.Error);
                    }
                }
            }
        }

        private async Task InitializeFileInDatabaseAsync()
        {
            if (_fileId != 0) return;
            _fileId = await _db.InitializeFileAsync(FileName, _totalBytes);
        }

        private async Task UploadAsync(CancellationToken token)
        {
            using (var fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            {
                UpdateStatus(DownloadTaskStatus.Loading, DownloadTaskStatus.Loading.ToFriendlyString());
                await UpdateStatusInDbAsync(DownloadTaskStatus.Loading);

                var buffer = new byte[_chunkSize];
                int bytesRead;
                while ((bytesRead = await fs.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                {
                    if (_isPaused || _isCanceled) throw new OperationCanceledException();

                    var chunk = new byte[bytesRead];
                    Array.Copy(buffer, chunk, bytesRead);

                    var parameters = new Dictionary<string, object>{
                        {"@p_id", _fileId},
                        {"@p_chunk", chunk},
                        {"@p_len", bytesRead},
                    };

                    await _db.ExecuteProcedureAsync("sp_UpdateFileChunk", parameters);

                    _uploadedBytes += bytesRead;
                    double progress = (double)_uploadedBytes / _totalBytes;
                    ProgressChanged?.Invoke(this, progress);
                }

                UpdateStatus(DownloadTaskStatus.Success, DownloadTaskStatus.Success.ToFriendlyString());
            }
        }

        private async Task UpdateStatusInDbAsync(DownloadTaskStatus status)
        {
            Status = status;
            var parameters = new Dictionary<string, object>
            {
                {"@p_id", _fileId},
                {"@p_status", status.ToFriendlyString()}
            };

            await _db.ExecuteProcedureAsync("sp_UpdateStatus", parameters);
        }

        public void Pause()
        {
            _isPaused = true;
            _cts?.Cancel();
        }

        public void Resume()
        {
            if (_isCanceled) return;
            _isPaused = false;
            _ = StartAsync();
        }

        public void Cancel()
        {
            _isCanceled = true;
            _cts?.Cancel();
            _ = UpdateStatusInDbAsync(DownloadTaskStatus.Canceled);
            UpdateStatus(DownloadTaskStatus.Canceled, DownloadTaskStatus.Canceled.ToFriendlyString());
        }

        private void UpdateStatus(DownloadTaskStatus status, string msg)
        {
            Status = status;
            StatusChanged?.Invoke(this, status, msg);
        }
    }
}
