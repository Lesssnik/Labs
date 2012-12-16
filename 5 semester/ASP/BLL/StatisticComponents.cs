using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entities;

namespace BLL
{
    public class StatisticComponents
    {
        private StatisticDBRepository Db;

        public StatisticComponents()
        {
            Db = new StatisticDBRepository();
        }

        public void AddStatistic(Statistic statistic)
        {
            Db.Create(statistic);
        }

        public IList<Statistic> GetTestStatistics()
        {
            return Db.Read();
        }

        public IList<Statistic> GetTestStatistic(User user)
        {
            return Db.Read(user);
        }

        public void DeleteStatistic(Statistic statistic)
        {
            Db.Delete(statistic);
        }
    }
}
