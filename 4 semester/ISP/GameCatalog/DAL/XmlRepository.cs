using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Entities;

namespace DAL
{
    public class XmlRepository
    {
        /// <summary>
        /// Сохраняет данные об играх в БД
        /// </summary>
        /// <param name="Path">Путь к БД</param>
        public static void Create(List<Game> games, string path)
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("Games");
            doc.AddFirst(root);

            foreach (Game game in games)
            {
                root.Add(new XElement("Game", new XAttribute("Title", game.Title),
                    new XAttribute("ID", game.ID),
                    new XAttribute("Genre", game.Genre.ToString()),
                    new XElement("Logo", game.Logo),
                    new XElement("Description", game.Description),
                    new XElement("Path", game.Exe)));
            }

            doc.Save(path);
        }

        public static void Create(Game game, string path)
        {
            XDocument doc = XDocument.Load(path);

            doc.Root.Add(new XElement("Game", new XAttribute("Title", game.Title),
                    new XAttribute("ID", game.ID),
                    new XAttribute("Genre", game.Genre.ToString()),
                    new XElement("Logo", game.Logo),
                    new XElement("Description", game.Description),
                    new XElement("Path", game.Exe)));

            doc.Save(path);
        }

        /// <summary>
        /// Загрузка данных об играх из БД 
        /// </summary>
        /// <param name="Path">Путь к БД</param>
        /// <returns>Список объектов класса Game</returns>
        public static List<Game> Read(string path)
        {
            XDocument doc = new XDocument();
            List<Game> Games = new List<Game>();
            try
            {
                doc = XDocument.Load(path);

                foreach (XElement elem in doc.Root.Elements())
                {
                    Game.GameGenre genre = (Game.GameGenre)Enum.Parse(typeof(Game.GameGenre), elem.Attribute("Genre").Value);
                    Games.Add(new Game(elem.Attribute("ID").Value, elem.Attribute("Title").Value, elem.Element("Description").Value, genre, elem.Element("Logo").Value, elem.Element("Path").Value));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Games;
        }

        public static Game Read(string path, string title)
        {
            XDocument doc = XDocument.Load(path);

            foreach (XElement elem in doc.Root.Elements())
            {
                foreach (XAttribute attr in elem.Attributes())
                {
                    if (attr.Value == title)
                    {
                        Game.GameGenre genre = (Game.GameGenre)Enum.Parse(typeof(Game.GameGenre), elem.Attribute("Genre").Value);
                        return new Game(elem.Attribute("ID").Value, elem.Attribute("Title").Value, elem.Element("Description").Value, genre, elem.Element("Logo").Value, elem.Element("Path").Value);
                    }
                }
            }
            return null;
        }

        public static void Update(List<Game> games, string path)
        {
            XDocument doc = XDocument.Load(path);
            foreach (Game game in games)
            {
                foreach (XElement elem in doc.Root.Elements())
                {
                    foreach (XAttribute attr in elem.Attributes())
                    {
                        if (attr.Value == game.ID)
                        {
                            elem.Remove();
                            doc.Root.Add(new XElement("Game", new XAttribute("Title", game.Title),
                        new XAttribute("ID", game.ID),
                        new XAttribute("Genre", game.Genre.ToString()),
                        new XElement("Logo", game.Logo),
                        new XElement("Description", game.Description),
                        new XElement("Path", game.Exe)));
                        }
                    }
                }
            }

            doc.Save(path);
        }

        public static void Update(Game game, string path)
        {
            XDocument doc = XDocument.Load(path);

            foreach (XElement elem in doc.Root.Elements())
            {
                foreach (XAttribute attr in elem.Attributes())
                {
                    if (attr.Value == game.ID)
                    {
                        elem.Remove();
                        doc.Root.Add(new XElement("Game", new XAttribute("Title", game.Title),
                    new XAttribute("ID", game.ID),
                    new XAttribute("Genre", game.Genre.ToString()),
                    new XElement("Logo", game.Logo),
                    new XElement("Description", game.Description),
                    new XElement("Path", game.Exe)));
                    }
                }
            }

            doc.Save(path);
        }

        public static void Delete(string id, string path)
        {
            XDocument doc = XDocument.Load(path);

            foreach (XElement elem in doc.Root.Elements())
            {
                foreach (XAttribute attr in elem.Attributes())
                {
                    if (attr.Value == id)
                    {
                        elem.Remove();
                    }
                }
            }

            doc.Save(path);
        }
    }
}
