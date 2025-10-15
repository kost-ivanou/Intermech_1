using System;
using System.IO;
using System.ServiceProcess;

namespace DiskMonitorService
{
    public class DiskMonitor : ServiceBase
    {
        private FileSystemWatcher watcher;
        private readonly string logPath = @"C:\DiskMonitor\log.txt";

        public DiskMonitor()
        {
            ServiceName = "DiskMonitorService";
        }

        protected override void OnStart(string[] args)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(logPath));

            watcher = new FileSystemWatcher
            {
                Path = @"D:\", 
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName
            };

            watcher.Deleted += OnFileDeleted;
            watcher.EnableRaisingEvents = true;

            WriteLog("Служба запущена.");
        }

        protected override void OnStop()
        {
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
            WriteLog("Служба остановлена.");
        }

        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            WriteLog($"Удален файл: {e.FullPath}");
        }

        private void WriteLog(string message)
        {
            File.AppendAllText(logPath, $"{DateTime.Now}, {message}\n");
        }

        static void Main()
        {
            ServiceBase.Run(new DiskMonitor());
        }
    }
}
