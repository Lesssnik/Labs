using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rumyantsev.Lab6.Player
{
    /// <summary>
    /// Class for working with .plst files
    /// </summary>
    class File
    {
        /// <summary>
        /// Save playlist to the current path
        /// </summary>
        /// <param name="Path">Current path</param>
        /// <param name="playlist">Playlist</param>
        static public void SavePlaylist(string Path, Playlist playlist)
        {
            FileStream fs = new FileStream(Path + ".plst", FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(playlist.ID);
            bw.Write(playlist.Name);

            bw.Write(playlist.Songs.Count);
            foreach (Song song in playlist.Songs)
            {
                SaveSong(bw, song);
            }

            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// Save song to the stream
        /// </summary>
        /// <param name="bw">Current stream</param>
        /// <param name="song">Song</param>
        static public void SaveSong(BinaryWriter bw, Song song)
        {
            bw.Write(song.ID);
            bw.Write(song.Name);
            bw.Write(song.Length.Item1);
            bw.Write(song.Length.Item2);
            bw.Write(song.Artist);
            bw.Write((byte)song.Genre);
            bw.Write(song.Rating);
        }

        /// <summary>
        /// Load information about playlist from file
        /// </summary>
        /// <param name="Path">Path to the file</param>
        /// <returns>Playlist</returns>
        static public Playlist LoadPlaylist(string Path)
        {
            try
            {
                FileStream fs = new FileStream(Path + ".plst", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                string ID = br.ReadString();
                string Name = br.ReadString();
                int Count = br.ReadInt32();
                List<Song> Songs = new List<Song>();
                for (int i = 0; i < Count; i++)
                {
                    Songs.Add(LoadSong(br));
                }
                br.Close();
                fs.Close();
                Playlist playlist = new Playlist(ID, Name);
                foreach (Song song in Songs)
                    playlist.AddSong(song);
                return playlist;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Load information about song from stream
        /// </summary>
        /// <param name="br">Current stream</param>
        /// <returns>Song</returns>
        static public Song LoadSong(BinaryReader br)
        {
            string ID = br.ReadString();
            string Name = br.ReadString();
            byte Minute = br.ReadByte();
            byte Second = br.ReadByte();
            string Artist = br.ReadString();
            byte Genre = br.ReadByte();
            byte Rating = br.ReadByte();
            return new Song(ID, Name, Minute, Second, Artist, Genre, Rating);
        }
    }
}
