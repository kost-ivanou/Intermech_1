using System.Collections.Generic;
using System.Threading.Tasks;

namespace Winform_4
{
    public class DownloadTaskManager
    {
        private readonly List<DownloadTask> _downloads = new List<DownloadTask>();

        public DownloadTask AddDownload(string filepath, string connectionString)
        {
            var task = new DownloadTask(filepath, connectionString);
            _downloads.Add(task);
            return task;
        }

        public void PauseAll()
        {
            foreach (var d in _downloads) d.Pause();
        }

        public void ResumeAll()
        {
            foreach (var d in _downloads) d.Resume();
        }
    }
}
