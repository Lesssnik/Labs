using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entities;

namespace BLL
{
    public class TestStatisticComponents
    {
        private TestStatisticDBRepository Db;

        public TestStatisticComponents()
        {
            Db = new TestStatisticDBRepository();
        }

        public void AddStatistic(TestStatistic statistic)
        {
            Db.Create(statistic);
        }

        public IList<TestStatistic> GetTestStatistics()
        {
            return Db.Read();
        }

        public IList<TestStatistic> GetTestStatistic(Test test)
        {
            return Db.Read(test);
        }
    }
}
