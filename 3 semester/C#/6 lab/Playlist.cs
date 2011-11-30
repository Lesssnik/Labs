using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Rumyantsev.Lab6.Player
{
    /// <summary>
    /// Class Playlist
    /// </summary>
    public class Playlist
    {
        /// <summary>
        /// Current thread
        /// </summary>
        public Thread thread
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Information, is this thread paused
        /// </summary>
        public bool isPaused
        {
            get;
            private set;
        }
        
        private Timer timer;

        /// <summary>
        /// List of songs
        /// </summary>
        public List<Song> Songs
        {
            get;
            private set;
        }

        /// <summary>
        /// Playlist ID
        /// </summary>
        public string ID
        {
            get;
            private set;
        }

        /// <summary>
        /// Playlist name
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Length of playlist
        /// </summary>
        public Tuple<byte, byte> Length
        {
            get;
            private set;
        }

        /// <summary>
        /// Playlist rating
        /// </summary>
        public double Rating
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor with parametrs
        /// </summary>
        /// <param name="id">Playlist ID</param>
        /// <param name="name">Playlist name</param>
        public Playlist(string id, string name)
        {
            Songs = new List<Song>();
            ID = id;
            Name = name;
            Length = new Tuple<byte, byte>(0, 0);
        }

        /// <summary>
        /// Add song to the playlist
        /// </summary>
        /// <param name="song">Song</param>
        public void AddSong(Song song)
        {
            if (Songs.Find(x => x.ID == song.ID) == null)
            {
                Songs.Add(song);
                Tuple<byte, byte> temp = new Tuple<byte, byte>((byte)(Length.Item1 + song.Length.Item1), (byte)(Length.Item2 + song.Length.Item2));
                if (temp.Item2 >= 60)
                    Length = new Tuple<byte, byte>((byte)(temp.Item1 + 1), (byte)(temp.Item2 - 60));
                else Length = temp;

                double rating = Songs.Average(x => x.Rating);
                Rating = rating;
            }
        }

        /// <summary>
        /// Convert information about current playlist to string format
        /// </summary>
        /// <returns>Information about current playlist</returns>
        public string ToString()
        {
            string info = "";
            info += "\n~~~~~~~~~~~~~~~~~\n";
            info += this.Name;
            info += "\n~~~~~~~~~~~~~~~~~\n";
            foreach (Song s in Songs)
            {
                info += s.ToString();
                info += "------------\n";

            } 
            return info;
        }

        //------------------------------------------------//

        /// <summary>
        /// Start playing playlist
        /// </summary>
        public void Start()
        {
            try
            {
                if (thread == null)
                {
                    thread = new Thread(PlaySong);
                    isPaused = false;
                    thread.Start();
                }
                else throw new Exception("This playlist is already playing");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Suspend playing
        /// </summary>
        public void Pause()
        {
            try
            {
                if (thread != null)
                {
                    if (isPaused == false)
                    {
                        isPaused = true;
                        thread.Suspend();
                        timer.Dispose();
                    }
                }
                else throw new Exception("This playlist is not alive");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Continue playing
        /// </summary>
        public void Continue()
        {
            try
            {
                if (thread != null)
                {
                    if (isPaused == true)
                    {
                        isPaused = false;
                        thread.Resume();
                        timer = new Timer((x) => Console.Beep(), null, 5000, 5000);
                    }
                }
                else throw new Exception("This playlist is not paused");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Stop playing
        /// </summary>
        public void Stop()
        {
            try
            {
                if (thread != null)
                {
                    if (isPaused == true)
                        thread.Resume();
                    isPaused = false;
                    thread.Abort();
                    thread = null;
                    timer.Dispose();
                }
                else throw new Exception("This playlist is not playing");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PlaySong()
        {
            timer = new Timer((x) => Console.Beep(), null, 5000, 5000);
            Thread.Sleep((this.Length.Item1 * 60 + this.Length.Item2) * 1000);
        }
    }
}