using System;
using System.IO;

namespace LocalActivityLogger
{
    class MainClass
    {
        static void Main(string[] args)
        {
            var logger = new FileActivityLogger();
            logger.StartMonitoring(@"C:\The\Path\To\Monitor");

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

    class FileActivityLogger
    {
        private FileSystemWatcher watcher;

        public void StartMonitoring(string path)
        {
            watcher = new FileSystemWatcher
            {
                Path = path,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size,
                Filter = "*.*" //use all file types
            };

            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;

            watcher.EnableRaisingEvents = true;
            Console.WriteLine($"Started monitoring: {path}");
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            LogEvent($"File {e.ChangeType}: {e.FullPath}");
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            LogEvent($"File Renamed from {e.OldFullPath} to {e.FullPath}");
        }

        private void LogEvent(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] {message}");
            File.AppendAllText("activity_log.txt", $"[{DateTime.Now}] {message}{Environment.NewLine}");
        }
    }
    }
}