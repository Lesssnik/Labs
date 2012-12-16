using System.Collections.Generic;
using System;

namespace Entities
{
    public class User
    {
        public Guid ID { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public Roles Role { get; set; }

        public User()
        {
            Login = "";
            Name = "";
            Surname = "";
            City = "";
            Password = "";
            ID = Guid.NewGuid();
        }

        public User(string login, string password, Guid id)
        {
            Login = login;
            Name = "";
            Surname = "";
            City = "";
            Password = password;
            ID = id;
            Role = Roles.User;
        }

        public User(string login, string password)
        {
            Login = login;
            Name = "";
            Surname = "";
            City = "";
            Password = password;
            ID = Guid.NewGuid();
            Role = Roles.User;
        }
    }
}
