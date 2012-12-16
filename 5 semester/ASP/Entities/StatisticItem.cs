using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class StatisticItem
    {
        public Guid ID { get; set; }

        public string Correct { get; set; }

        public StatisticItem()
        {
            ID = Guid.NewGuid();
        }
    }
}
