using System;
using System.Collections.Generic;
namespace MvсTester.Models
{
    public class Test
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Question> Questions { get; set; }

        public string Author { get; set; }

        public Test()
        {
            Name = "";
            Description = "";
            Questions = new List<Question>();
            Author = "";
            Id = Guid.NewGuid();
        }
    }
}