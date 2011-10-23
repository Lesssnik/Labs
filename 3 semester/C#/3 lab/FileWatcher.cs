using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Rumyantsev.Lab2.Railroad;

namespace Rumyantsev.Lab3.Files
{
    /// <summary>
    /// Class, that watch for a file
    /// </summary>
    class FileWatcher: IDisposable
    {
        /// <summary>
        /// Path to the file
        /// </summary>
        public string Path
        {
            get;
            set;
        }

        /// <summary>
        /// The events caused by a change or rename a file.
        /// </summary>
        public event FileChanged Changed = delegate {};
        public event FileRenamed Renamed = delegate {};

        public delegate void FileChanged(string path, FileSystemEventArgs e);
        public delegate void FileRenamed(string path, RenamedEventArgs e);

        private FileSystemWatcher Watcher;

        /// <summary>
        /// Constructor with parametrs
        /// </summary>
        /// <param name="path">Path to the file</param>
        public FileWatcher(string path)
        {
            Path = path;
            Watcher = new FileSystemWatcher(path);
            Watcher.Changed += new FileSystemEventHandler(Watcher_Event);
            Watcher.Deleted += new FileSystemEventHandler(Watcher_Event);
            Watcher.Renamed += new RenamedEventHandler(Watcher_Renamed);
            Watcher.EnableRaisingEvents = true;
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Renamed(Path, e);
        }

        private void Watcher_Event(object sender, FileSystemEventArgs e)
        {
            Changed(Path, e);
        }

        /// <summary>
        /// Dispose for watcher
        /// </summary>
        public void Dispose()
        {
            Watcher.Dispose();
        }
    }
}
