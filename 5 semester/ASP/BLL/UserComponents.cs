using System.Collections.Generic;
using Entities;
using DAL;

namespace BLL
{
    public class UserComponents
    {
        private UserDBRepository Db;

        public UserComponents()
        {
            Db = new UserDBRepository();
        }

        public void CreateUser(string Login, string Password, string Email)
        {
            Db.Create(Login, Password, Email);
        }

        public User GetUser(string Login, string Password)
        {
            return Db.Read(Login, Password);
        }

        public User GetUser(string Login)
        {
            return Db.Read(Login);
        }

        public IList<User> GetUsers()
        {
            return Db.Read();
        }

        public void UpdateUser(User user)
        {
            Db.Update(user);
        }
    }
}
