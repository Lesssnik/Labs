using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Game
    {
        /// <summary>
        /// Жанр 
        /// </summary>
        public enum GameGenre
        {
            Action,
            Arcade,
            Fighting,
            Indie,
            Other,
            Quest,
            Racing,
            RPG,
            Shooter,
            Simulator,
            Sport,
            Stealth_action,
            Strategy
        }
        
        /// <summary>
        /// Уникальные идентификатор игры
        /// </summary>
        public readonly string ID;

        /// <summary>
        /// Название игры
        /// </summary>
        public readonly string Title;

        /// <summary>
        /// Описание игры
        /// </summary>
        public string Description;

        /// <summary>
        /// Жанр
        /// </summary>
        public readonly GameGenre Genre;
        
        /// <summary>
        /// Путь к файлу с изображением-логотипом
        /// </summary>
        public string Logo;

        /// <summary>
        /// Путь к исполняемому файлу
        /// </summary>
        public readonly string Exe;

        public Game(string title, string description, GameGenre genre, string exe)
        {
            ID = this.GetHashCode().ToString();
            Title = title;
            Description = description;
            Genre = genre;
            Logo = "#";
            Exe = exe;
        }

        public Game(string title, string description, GameGenre genre, string logo, string exe)
        {
            ID = this.GetHashCode().ToString();
            Title = title;
            Description = description;
            Genre = genre;
            Logo = logo;
            Exe = exe;
        }

        public Game(string id, string title, string description, GameGenre genre, string logo, string exe)
        {
            ID = id;
            Title = title;
            Description = description;
            Genre = genre;
            Logo = logo;
            Exe = exe;
        }

        public int CompareTo(Game other)
        {
            return Title.CompareTo(other.Title);
        }
    }
}
