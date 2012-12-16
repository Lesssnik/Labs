using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfTester
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInfoServiceClient client = new UserInfoServiceClient();
            Console.WriteLine("Число пользователей: " + client.GetUsersCount());
            Console.WriteLine("Число тестов, созданных пользователем Admin: " + client.GetUserTestsCount("Admin"));
            Console.ReadKey();
        }
    }
}
