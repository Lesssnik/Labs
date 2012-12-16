using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace DAL
{
    public class TestDBRepository : ITestDbRepository
    {
        private static TestDBRepository repos;

        private static EntityContext context;

        private TestDBRepository()
        {
            context = new EntityContext();
        }

        public static TestDBRepository TestRepository
        {
            get
            {
                if (repos == null)
                    repos = new TestDBRepository();
                return repos;
            }
        }

        public void Create(Test Test)
        {
            context.Tests.Add(Test);
            context.SaveChanges();
        }

        public IList<Test> Read()
        {
            return context.Tests.ToList();
        }

        public IList<Test> Read(string Author)
        {
            return context.Tests.Where(t => t.Author == Author).ToList();
        }

        public IList<Test> Read(Types Type)
        {
            return context.Tests.Where(t => t.Type.ToString() == Type.ToString()).ToList();
        }

        public bool Update(Test Test)
        {
            Test tst = context.Tests.Where(t => t.Id == Test.Id).First();
            if (tst != null)
            {
                tst.Name = Test.Name;
                tst.Description = Test.Description;
                tst.Time = Test.Time;
                tst.Type = Test.Type;
                tst.Questions = Test.Questions;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(Test Test)
        {
            foreach (var stat in context.Statistics)
                if (stat.TestName == Test.Name)
                    context.Statistics.Remove(stat);
            var test = context.Tests.Where(t => t.Id == Test.Id).First();
            test.Questions.Clear();
            context.Tests.Remove(test);
            context.SaveChanges();

            return true;
        }

        public bool Delete()
        {
            foreach (Test test in context.Tests)
                context.Tests.Remove(test);

            context.SaveChanges();

            return true;
        }  
    }
}
