using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace DAL
{
    public class TestStatisticDBRepository : ITestStatisticDbRepository
    {
        private EntityContext context;

        public TestStatisticDBRepository()
        {
            context = new EntityContext();
        }

        public void Create(TestStatistic statistic)
        {
            context.TestStatistic.Add(statistic);
            context.SaveChanges();
        }

        public IList<TestStatistic> Read()
        {
            return context.TestStatistic.ToList();
        }

        public IList<TestStatistic> Read(Test test)
        {
            return context.TestStatistic.Where(s => s.TestID == test.ID).ToList();
        }
    }
}
