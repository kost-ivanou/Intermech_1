using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.IO;

namespace Winform_5
{
    public class FileSearcher
    {
        public event EventHandler<SearchResultEventArgs> ItemFound;
        public event EventHandler SearchCompleted;

        public void StartSearch(string startPath, string mask, int threadCount)
        {
            var queue = new ConcurrentQueue<string>();
            var hasFiles = new ConcurrentDictionary<string, bool>(); 
            queue.Enqueue(startPath);

            var tasks = new List<Task>();

            for (int i = 0; i < threadCount; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    while (queue.TryDequeue(out string currentDir))
                    {
                        bool foundSomething = false;

                        try
                        {
                            foreach (var file in Directory.GetFiles(currentDir, mask))
                            {
                                foundSomething = true;
                                OnItemFound(currentDir, file, false);
                            }

                            foreach (var dir in Directory.GetDirectories(currentDir))
                            {
                                queue.Enqueue(dir);
                            }
                        }
                        catch (UnauthorizedAccessException)
                        {
                            continue;
                        }
                        catch (DirectoryNotFoundException)
                        {
                            continue;
                        }

                        if (foundSomething)
                        {
                            hasFiles[currentDir] = true;
                            var parent = Path.GetDirectoryName(currentDir);
                            while (!string.IsNullOrEmpty(parent))
                            {
                                hasFiles[parent] = true;
                                parent = Path.GetDirectoryName(parent);
                            }
                        }
                    }
                }));
            }

            Task.WhenAll(tasks).ContinueWith(t =>
            {
                foreach (var dir in hasFiles.Keys)
                {
                    var parent = Path.GetDirectoryName(dir);
                    OnItemFound(parent, dir, true);
                }

                SearchCompleted?.Invoke(this, EventArgs.Empty);
            });
        }

        private void OnItemFound(string parent, string path, bool isFolder)
        {
            ItemFound?.Invoke(this, new SearchResultEventArgs(parent, path, isFolder));
        }
    }
}
