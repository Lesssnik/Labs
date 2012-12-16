using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entities;

namespace BLL
{
    public class UserStatisticComponents
    {
        private UserStatisticDBRepository Db;

        public UserStatisticComponents()
        {
            Db = new UserStatisticDBRepository();
        }

        public void AddStatistic(UserStatistic statistic)
        {
            Db.Create(statistic);
        }

        public IList<UserStatistic> GetTestStatistics()
        {
            return Db.Read();
        }

        public IList<UserStatistic> GetTestStatistic(User user)
        {
            return Db.Read(user);
        }
    }
}
