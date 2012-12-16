using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace DAL
{
    public class UserStatisticDBRepository : IUserStatisticDbRepository
    {
        private EntityContext context;

        public UserStatisticDBRepository()
        {
            context = new EntityContext();
        }

        public void Create(UserStatistic statistic)
        {
            context.UserStatistic.Add(statistic);
            context.SaveChanges();
        }

        public IList<UserStatistic> Read()
        {
            return context.UserStatistic.ToList();
        }

        public IList<UserStatistic> Read(User user)
        {
            return context.UserStatistic.Where(s => s.UserID == user.ID).ToList();
        }
    }
}