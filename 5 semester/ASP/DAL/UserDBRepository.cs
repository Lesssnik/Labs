using Entities;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DAL
{
    public class UserDBRepository : IUserDbRepository
    {
        private EntityContext context;

        public UserDBRepository()
        {
            context = new EntityContext();
        }

        public void Create(string login, string password, string email)
        {
            if (context.Users.Where(u => u.Login == "Admin").Count() == 0)
                context.Users.Add(new User("Admin", "admin") { Role = Roles.Admin });
            if (context.Users.Where(u => u.Login == login).Count() == 0)
                context.Users.Add(new User() { Login = login, Password = password, Email = email, Role = Roles.User});
            else throw new Exception("Пользователь с таким имененем уже создан");
            context.SaveChanges();
        }

        public User Read(string Login, string Password)
        {
            User user = context.Users.FirstOrDefault(u => u.Login == Login);
            if (user != null)
                if(user.Password == Password)
                {
                    return user;
                }
            return null;
        }

        public User Read(string Login)
        {
            User user = context.Users.FirstOrDefault(u => u.Login == Login);
            if (user != null)
            {
                if (user.Login== "Admin")
                    user.Role = Roles.Admin;
                else user.Role = Roles.User;
            }
            return user;
        }

        public IList<User> Read()
        {
            return context.Users.ToList();
        }

        public bool Update(User user)
        {
            User usr = context.Users.Where(u => u.Login == user.Login).First();
            if (usr != null)
            {
                usr.Name = user.Name;
                usr.Surname = user.Surname;
                usr.City = user.City;
                usr.Password = user.Password;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
            return true;
        }
    }
}
