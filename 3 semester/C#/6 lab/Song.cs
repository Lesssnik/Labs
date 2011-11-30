using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumyantsev.Lab6.Player
{
    /// <summary>
    /// Class Song
    /// </summary>
    public class Song
    {
        /// <summary>
        /// Song ID
        /// </summary>
        public string ID
        {
            get;
            private set;
        }

        /// <summary>
        /// Song name
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Song length
        /// </summary>
        public Tuple<byte, byte> Length
        {
            get;
            private set;
        }

        /// <summary>
        /// Name of singer
        /// </summary>
        public string Artist
        {
            get;
            private set;
        }

        /// <summary>
        /// Genre
        /// </summary>
        public enum genre: byte
        {
            Pop = 0,
            Rock = 1, 
            Classic = 2,
            Jazz = 3,
            Alternative = 4,
            HipHop = 5,
            Folk = 6,
            RnB = 7,
            Country = 8,
            Stage = 9,
            Metal = 10,
            Relax = 11,
            Dance = 12,
            Reggie = 13,
            Blues = 14
        }

        /// <summary>
        /// Current genre
        /// </summary>
        public genre Genre
        {
            get;
            private set;
        }

        /// <summary>
        /// Song rating
        /// </summary>
        public byte Rating
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor with parametrs
        /// </summary>
        /// <param name="id">Song ID</param>
        /// <param name="name">Song name</param>
        /// <param name="minute">Song length (minute)</param>
        /// <param name="second">Song length (second)</param>
        /// <param name="artist">Artist</param>
        /// <param name="genre">Song genre</param>
        /// <param name="rating">Song rating</param>
        public Song(string id, string name, byte minute, byte second, string artist, byte genre, byte rating)
        {
            ID = id;
            Name = name;
            Length = new Tuple<byte, byte>(minute, second);
            Artist = artist;
            Genre = (genre)genre;
            Rating = rating;
        }

        /// <summary>
        /// Convert information about song to the string format
        /// </summary>
        /// <returns>Information about song</returns>
        public string ToString()
        {
            string text = "";
            text += this.Artist + '\n';
            text += this.Name + '\n';
            text += this.Genre.ToString() + '\n';
            text += this.Length.ToString() + '\n';
            return text;
        }
    }
}
