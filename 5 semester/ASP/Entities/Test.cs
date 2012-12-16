using System;
using System.Collections.Generic;

namespace Entities
{
    public sealed class Test
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Question> Questions { get; set; }

        public Types Type { get; set; }

        public string Author { get; set; }

        public TimeSpan Time { get; set; }

        public Test()
        {
            Name = "";
            Description = "";
            Questions = new List<Question>();
            Type = Types.Programming;
            Author = "";
            Id = Guid.NewGuid();
        }
    }
}
