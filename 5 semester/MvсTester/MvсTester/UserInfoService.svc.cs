using System.Linq;
using MvсTester.Models;

namespace MvсTester
{
    public class UserInfoService : IUserInfoService
    {
        TesterEntities testerDb = new TesterEntities();

        public int GetUsersCount()
        {
            return testerDb.Users.Count();
        }

        public int GetUserTestsCount(string user)
        {
            return testerDb.Tests.Where(t => t.Author.CompareTo(user) == 0).Count();
        }
    }
}
