using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Statistic
    {
        public Guid ID { get; set; }

        public string TestName { get; set; }

        public Guid UserId { get; set; }

        public virtual List<StatisticItem> CorrectQuestions { get; set; }

        public Statistic()
        {
            ID = Guid.NewGuid();
            CorrectQuestions = new List<StatisticItem>();
        }
    }
}
