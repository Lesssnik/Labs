using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using DAL;

namespace BLL
{
    public static class UserComponents
    {
        public static void AddGame(User user, string gameid)
        {
            if (!user.GamesID.Contains(gameid))
                user.GamesID.Add(gameid);
            user.GamesID.Sort(delegate(string g1, string g2) { return g1.CompareTo(g2); });
        }

        public static void SaveUsers(string path, List<User> users)
        {
            XML.SaveUsers(path, users);
        }

        public static List<User> LoadUsers(string path)
        {
            return XML.LoadUsers(path);
        }

        private static string GetPassword(string pass, User user)
        {
            return user.Password;
        }
    }
}
