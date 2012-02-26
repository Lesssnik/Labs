using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using DAL;
using Entities;

namespace BLL
{
    public static class GameComponents
    {
        public static void SaveGame(Game game, string path)
        {
            XmlRepository.Create(game, path);
        }

        public static Game LoadGame(string path, string title)
        {
            return XmlRepository.Read(path, title);
        }

        public static void UpdateGame(Game game, string path)
        {
            XmlRepository.Update(game, path);
        }

        public static void DeleteGame(string id, string path)
        {
            XmlRepository.Delete(id, path);
        }

        public static void PlayGame(Game game)
        {
            try
            {
                Process.Start(game.Exe);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
