using System;
using System.Collections.Generic;

namespace Entities
{
    public class UserStatistic
    {
        public Guid ID { get; set; }

        public Guid UserID { get; set; }

        public Dictionary<Guid, bool> Stat { get; set; }

        public UserStatistic()
        {
            ID = Guid.NewGuid();
            UserID = Guid.NewGuid();
            Stat = new Dictionary<Guid, bool>();
        }
    }
}
