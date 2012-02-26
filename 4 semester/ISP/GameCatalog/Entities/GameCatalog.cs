using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class GameCatalog
    {
        public List<Game> Games
        {
            get;
            private set;
        }

        public string Name;

        public int Count
        {
            get { return Games.Count; }
        }

        public GameCatalog(List<Game> games)
        {
            Games = games;
        }

        public GameCatalog()
        {
             Games = new List<Game>();
        }

        public Game this[int index]
        {
            get
            {
                return Games[index];
            }
        }
    }
}
