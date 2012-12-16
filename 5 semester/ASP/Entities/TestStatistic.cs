using System;
using System.Collections.Generic;

namespace Entities
{
    public class TestStatistic
    {
        public Guid ID { get; set; }

        public Guid TestID { get; set; }

        public Dictionary<User, bool> Stat { get; set; }

        public TestStatistic()
        {
            ID = Guid.NewGuid();
            TestID = Guid.NewGuid();
            Stat = new Dictionary<User, bool>();
        }
    }
}
