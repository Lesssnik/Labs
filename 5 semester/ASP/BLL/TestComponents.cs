using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using DAL;

namespace BLL
{
    public class TestComponents
    {
        private TestDBRepository Db;

        public TestComponents()
        {
            Db = TestDBRepository.TestRepository;
        }

        public void AddTest(Test test)
        {
            Db.Create(test);
        }

        public IList<Test> GetTests()
        {
            return Db.Read();
        }

        public IList<Test> GetTests(string Author)
        {
            return Db.Read(Author);
        }

        public IList<Test> GetTests(Types type)
        {
            return Db.Read(type);
        }

        public bool UpdateTest(Test test)
        {
            return Db.Update(test);
        }

        public bool DeleteTest(Test test)
        {
            return Db.Delete(test);
        }

        public bool DeleteTests()
        {
            return Db.Delete();
        }

        public List<Test> FindTest(string name)
        {
            List<Test> tests = new List<Test>();
            if (name != null)
                tests.AddRange(Db.Read().Where(t => t.Name.Contains(name)));
            
            return tests;
        }

        public Test FindTest(Guid id)
        {
            Test test = null;
            if (id != null)
                test = Db.Read().Where(t => t.Id == id).FirstOrDefault();

            return test;
        }
    }
}