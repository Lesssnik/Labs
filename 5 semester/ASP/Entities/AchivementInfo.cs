using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class AchivementInfo
    {
        public Guid ID { get; set; }

        public Guid AchivementId { get; set; }

        public User User { get; set; }

        public AchivementInfo()
        {
        }
    }
}
