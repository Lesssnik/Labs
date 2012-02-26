using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class User
    {
        public List<string> GamesID
        {
            get;
            private set;
        }

        public readonly string ID;

        public string Login
        {
            get;
            private set;
        }

        public string Password
        {
            get;
            private set;
        }

        public User(string login, string password)
        {
            GamesID = new List<string>();
            ID = this.GetHashCode().ToString();
            Login = login;
            Password = password;
        }

        public User(List<string> games, string login, string password, string id)
        {
            ID = this.GetHashCode().ToString();
            GamesID = games;
            Login = login;
            Password = password;
            ID = id;
        }
    }
}
