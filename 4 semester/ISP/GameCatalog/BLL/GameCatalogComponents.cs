using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using DAL;

namespace BLL
{
    public static class GameCatalogComponents
    {
        public static void SaveCatalog(GameCatalog catalog, string path)
        {
            XmlRepository.Create(catalog.Games, path);
        }

        public static GameCatalog LoadCatalog(string path)
        {
            return new GameCatalog(XmlRepository.Read(path));
        }

        public static void UpdateCatalog(GameCatalog catalog, string path)
        {
            XmlRepository.Update(catalog.Games, path);
        }

        public static void AddGame(Game game, GameCatalog catalog)
        {
            if (!catalog.Games.Contains(game))
                catalog.Games.Add(game);
        }

        public static void UpdateGame(Game game, GameCatalog catalog, int index)
        {
            catalog.Games[index] = game;
        }

        public static void DeleteGame(Game game, GameCatalog catalog)
        {
            catalog.Games.Remove(game);
        }

        public static void SortByTitle(GameCatalog catalog)
        {
            catalog.Games.Sort(delegate(Game g1, Game g2)
            { return g1.Title.CompareTo(g2.Title); });
        }
    }
}
