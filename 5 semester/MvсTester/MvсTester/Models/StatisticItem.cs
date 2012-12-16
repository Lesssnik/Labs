using System;
namespace MvсTester.Models
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
