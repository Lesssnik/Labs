using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using BLL;
using Entities;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            GameCatalog catalog = FirstMenu();
            GameMenu(catalog);
        }

        static GameCatalog FirstMenu()
        {
            int cmdint = 0;
            string cmd = "";

            while (true)
            {
                Console.Clear();
                int i = 1;
                Console.WriteLine("Выберите каталог из списка или создайте новый");
                string[] files = Directory.GetFiles("DB");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                foreach (string name in files)
                {
                    Console.WriteLine(i + ") " + name);
                    i++;
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Введите Create чтобы создать новый каталог");
                Console.WriteLine("Введите Delete чтобы удалить каталог");
                Console.Write("-> ");
                cmd = Console.ReadLine();

                if (cmd == "Create")
                {
                    Console.WriteLine("Введите название файла");
                    Console.Write("-> ");
                    string filename = Console.ReadLine();
                    FileStream fs = File.Create("DB\\" + filename + ".xdb");
                    fs.Close();
                    GameCatalog catalog = new GameCatalog();
                    string fullname = "DB\\" + filename + ".xdb";
                    GameCatalogComponents.SaveCatalog(catalog, fullname);
                    catalog.Name = fullname;
                    return catalog;
                }
                else if (cmd == "Delete")
                {
                    Console.WriteLine("Введите номер удаляемого файла");
                    Console.Write("-> ");
                    string index = Console.ReadLine();
                    File.Delete(files[int.Parse(index) - 1]);
                }
                else if (int.TryParse(cmd, out cmdint))
                {
                    GameCatalog catalog = GameCatalogComponents.LoadCatalog(files[cmdint - 1]);
                    catalog.Name = files[cmdint - 1];
                    return catalog;
                }
            }
        }

        static void GameMenu(GameCatalog catalog)
        {
            string cmd = "";

            while (cmd != "Exit")
            {
                Console.Clear();
                int i = 1;
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                foreach (Game game in catalog.Games)
                {
                    Console.WriteLine(i + ") " + game.Title);
                    i++;
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                Console.WriteLine("Введите Play чтобы запустить игру");
                Console.WriteLine("Введите Add чтобы добавить игру");
                Console.WriteLine("Введите Update чтобы обновить информацию об игре");
                Console.WriteLine("Введите Delete чтобы удалить игру");
                Console.WriteLine("Введите Exit чтобы выйти из программы");
                Console.Write("-> ");
                cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "Play":
                        try
                        {
                        Console.WriteLine("Выберите игру, которую хотите запустить");
                        Console.Write("-> ");
                        int index1 = int.Parse(Console.ReadLine()) - 1;
                        GameComponents.PlayGame(catalog.Games[index1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "Add":
                        GameCatalogComponents.AddGame(CreateGame(), catalog);
                        GameCatalogComponents.SaveCatalog(catalog, catalog.Name);
                        GameCatalogComponents.SortByTitle(catalog);
                        break;
                    case "Update":
                        try
                        {
                            Console.WriteLine("Выберите игру, которую хотите обновить");
                            Console.Write("-> ");
                            int index2 = int.Parse(Console.ReadLine()) - 1;
                            if (index2 > catalog.Count)
                                throw new Exception("Игры под таким номером нет");
                            Game newgame = UpdateGame(catalog.Games[index2].ID);
                            GameComponents.UpdateGame(newgame, catalog.Name);
                            GameCatalogComponents.UpdateGame(newgame, catalog, index2);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "Delete":
                        try
                        {
                            Console.WriteLine("Выберите игру, которую хотите удалить");
                            Console.Write("-> ");
                            int index3 = int.Parse(Console.ReadLine()) - 1;
                            if (index3 > catalog.Count)
                                throw new Exception("Игры под таким номером нет");
                            GameComponents.DeleteGame(catalog.Games[index3].ID, catalog.Name);
                            GameCatalogComponents.DeleteGame(catalog.Games[index3], catalog);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }

        static Game CreateGame()
        {
            Console.WriteLine("Введите название игры");
            Console.Write("-> ");
            string title = Console.ReadLine();
            Console.WriteLine("Введите описание игры");
            Console.Write("-> ");
            string description = Console.ReadLine();
            Console.WriteLine("Выберите жанр игры");
            Console.WriteLine("Action, Arcade, Fighting, Indie, Other, Quest, Racing, RPG, Shooter, Simulator, Sport, Stealth_action, Strategy");
            Console.Write("-> ");
            string genre = Console.ReadLine();
            Game.GameGenre gg = Game.GameGenre.Other;
            switch (genre)
            {
                case "Action":
                    gg = Game.GameGenre.Action;
                    break;
                case "Arcade":
                    gg = Game.GameGenre.Arcade;
                    break;
                case "Fighting":
                    gg = Game.GameGenre.Fighting;
                    break;
                case "Indie":
                    gg = Game.GameGenre.Indie;
                    break;
                case "Other":
                    gg = Game.GameGenre.Other;
                    break;
                case "Quest":
                    gg = Game.GameGenre.Quest;
                    break;
                case "Racing":
                    gg = Game.GameGenre.Racing;
                    break;
                case "RPG":
                    gg = Game.GameGenre.RPG;
                    break;
                case "Shooter":
                    gg = Game.GameGenre.Shooter;
                    break;
                case "Simulator":
                    gg = Game.GameGenre.Simulator;
                    break;
                case "Sport":
                    gg = Game.GameGenre.Sport;
                    break;
                case "Stealth_action":
                    gg = Game.GameGenre.Stealth_action;
                    break;
                case "Strategy":
                    gg = Game.GameGenre.Strategy;
                    break;
            }
            Console.WriteLine("Введите путь к .exe файлу игры");
            Console.Write("-> ");
            string exe = Console.ReadLine();
            return new Game(title, description, gg, exe);
        }

        static Game UpdateGame(string id)
        {
            Console.WriteLine("Введите название игры");
            Console.Write("-> ");
            string title = Console.ReadLine();
            Console.WriteLine("Введите описание игры");
            Console.Write("-> ");
            string description = Console.ReadLine();
            Console.WriteLine("Выберите жанр игры");
            Console.WriteLine("Action, Arcade, Fighting, Indie, Other, Quest, Racing, RPG, Shooter, Simulator, Sport, Stealth_action, Strategy");
            Console.Write("-> ");
            string genre = Console.ReadLine();
            Game.GameGenre gg = Game.GameGenre.Other;
            switch (genre)
            {
                case "Action":
                    gg = Game.GameGenre.Action;
                    break;
                case "Arcade":
                    gg = Game.GameGenre.Arcade;
                    break;
                case "Fighting":
                    gg = Game.GameGenre.Fighting;
                    break;
                case "Indie":
                    gg = Game.GameGenre.Indie;
                    break;
                case "Other":
                    gg = Game.GameGenre.Other;
                    break;
                case "Quest":
                    gg = Game.GameGenre.Quest;
                    break;
                case "Racing":
                    gg = Game.GameGenre.Racing;
                    break;
                case "RPG":
                    gg = Game.GameGenre.RPG;
                    break;
                case "Shooter":
                    gg = Game.GameGenre.Shooter;
                    break;
                case "Simulator":
                    gg = Game.GameGenre.Simulator;
                    break;
                case "Sport":
                    gg = Game.GameGenre.Sport;
                    break;
                case "Stealth_action":
                    gg = Game.GameGenre.Stealth_action;
                    break;
                case "Strategy":
                    gg = Game.GameGenre.Strategy;
                    break;
            }
            Console.WriteLine("Введите путь к .exe файлу игры");
            Console.Write("-> ");
            string exe = Console.ReadLine();
            return new Game(id, title, description, gg, "#", exe);
        }
    }
}