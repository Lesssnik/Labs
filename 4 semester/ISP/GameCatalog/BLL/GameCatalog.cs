using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace BLL
{
    public class GameCatalog
    {
        public List<User> Users
        {
            get;
            private set;
        }

        public List<Game> Games
        {
            get;
            private set;
        }

        public GameCatalog(List<User> users, List<Game> games)
        {
            Users = new List<User>(users);
            Games = new List<Game>(games);
        }

        public GameCatalog()
        {
            Users = new List<User>();
            Games = new List<Game>();
        }

        public void AddUser(User user)
        {
            if (!Users.Contains(user))
                Users.Add(user);
        }

        public void AddGame(Game game)
        {
            if (!Games.Contains(game))
                Games.Add(game);
        }
    }
}
