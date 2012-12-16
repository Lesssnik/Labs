using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace DAL
{
    public class StatisticDBRepository : IStatisticDbRepository
    {
        private EntityContext context;

        public StatisticDBRepository()
        {
            context = new EntityContext();
        }

        public void Create(Statistic statistic)
        {
            context.Statistics.Add(statistic);
            context.SaveChanges();
        }

        public void Delete(Statistic statistic)
        {
            var stat = context.Statistics.Where(s => s.ID == statistic.ID).First();
            context.Statistics.Remove(stat);
        }

        public IList<Statistic> Read()
        {
            return context.Statistics.ToList();
        }

        public IList<Statistic> Read(User user)
        {
            if (user != null)
                return context.Statistics.Where(s => s.UserId == user.ID).ToList();
            return null;
        }
    }
}