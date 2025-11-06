using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace Winform_4
{
    public class DownloadTask
    {
        private readonly string _filePath;
        private readonly string _connectionString;
        private readonly int _chunkSize = 1 * 1024 * 1024;

        private bool _isPaused;
        private bool _isCanceled;
        public long _uploadedBytes;
        public long _totalBytes;
        private int _fileId;
        private int _retryCount;
        private CancellationTokenSource _cts;

        public event Action<DownloadTask, double> ProgressChanged;
        public event Action<DownloadTask, string> StatusChanged;

        public string FileName => Path.GetFileName(_filePath);
        public string Status { get; private set; }

        public DownloadTask(string filePath, string connectionString)
        {
            _filePath = filePath;
            _connectionString = connectionString;
            _totalBytes = new FileInfo(filePath).Length;

            if (_totalBytes > 256 * 1024 * 1024)
                throw new InvalidOperationException("Размер файла превышает 256 МБ.");
        }

        public async Task StartAsync()
        {
            _cts = new CancellationTokenSource();
            _isPaused = false;
            _isCanceled = false;
            _retryCount = 0;

            int maxRetries = 3;

            while (_retryCount < maxRetries)
            {
                try
                {
                    await InitializeFileInDatabaseAsync();
                    await UploadAsync(_cts.Token);
                    break;
                }
                catch (OperationCanceledException)
                {
                    UpdateStatus(_isPaused ? "Пауза" : "Отменено");
                    break;
                }
                catch (Exception ex)
                {
                    _retryCount++;
                    UpdateStatus($"Ошибка: {ex.Message}");

                    if (_retryCount < maxRetries)
                    {
                        UpdateStatus($"Повтор {_retryCount}/{maxRetries}...");
                        await Task.Delay(2000);
                    }
                    else
                    {
                        UpdateStatus("Ошибка загрузки");
                    }
                }
            }
        }


        private async Task InitializeFileInDatabaseAsync()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new MySqlCommand(
                    "INSERT INTO files (file_name, total_bytes, uploaded_bytes, status) VALUES (@n, @t, 0, 'Начато');",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@n", FileName);
                    cmd.Parameters.AddWithValue("@t", _totalBytes);
                    await cmd.ExecuteNonQueryAsync();
                }

                using (var cmd2 = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
                {
                    object result = await cmd2.ExecuteScalarAsync();
                    _fileId = Convert.ToInt32(result);
                }
            }
        }

        private async Task UploadAsync(CancellationToken token)
        {
            using (var fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync(token);

                UpdateStatus("Загрузка...");

                var buffer = new byte[_chunkSize];
                int bytesRead;
                while ((bytesRead = await fs.ReadAsync(buffer, 0, buffer.Length, token)) > 0)
                {
                    if (_isPaused || _isCanceled)
                        throw new OperationCanceledException();

                    using (var cmd = new MySqlCommand(
                        "UPDATE files SET file_data = IFNULL(CONCAT(file_data, @chunk), @chunk), " +
                        "uploaded_bytes = uploaded_bytes + @len WHERE id = @id;",
                        conn))
                    {
                        var chunk = new byte[bytesRead];
                        Array.Copy(buffer, chunk, bytesRead);

                        cmd.Parameters.Add("@chunk", MySqlDbType.Blob).Value = chunk;
                        cmd.Parameters.AddWithValue("@len", bytesRead);
                        cmd.Parameters.AddWithValue("@id", _fileId);

                        await cmd.ExecuteNonQueryAsync(token);
                    }

                    _uploadedBytes += bytesRead;
                    double progress = (double)_uploadedBytes / _totalBytes;
                    ProgressChanged?.Invoke(this, progress);
                }

                UpdateStatus("Завершено");

                using (var cmdFinal = new MySqlCommand("UPDATE files SET status='Готово' WHERE id=@id;", conn))
                {
                    cmdFinal.Parameters.AddWithValue("@id", _fileId);
                    await cmdFinal.ExecuteNonQueryAsync();
                }
            }
        }

        public void Pause()
        {
            _isPaused = true;
            _cts?.Cancel();
        }

        public void Resume()
        {
            if (!_isPaused) return;
            _isPaused = false;
            _ = StartAsync();
        }

        public void Cancel()
        {
            _isCanceled = true;
            _cts?.Cancel();
        }

        private void UpdateStatus(string status)
        {
            Status = status;
            StatusChanged?.Invoke(this, status);
        }
    }
}
