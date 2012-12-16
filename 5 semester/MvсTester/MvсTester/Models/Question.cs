using System;
using System.Collections.Generic;
namespace MvсTester.Models
{
    public class Question
    {
        public Guid ID { get; set; }

        public string Text { get; set; }

        public virtual List<Answer> Answers { get; set; }

        public Question()
        {
            Text = "";
            Answers = new List<Answer>();
            ID = Guid.NewGuid();
        }

        public Question(string text)
        {
            Text = text;
            Answers = new List<Answer>();
            ID = Guid.NewGuid();
        }

        public Question(string text, Guid id)
        {
            Text = text;
            Answers = new List<Answer>();
            ID = id;
        }

        public Question(string text, List<Answer> answers)
        {
            Text = text;
            Answers = answers;
            ID = Guid.NewGuid();
        }

        public Question(string text, List<Answer> answers, Guid id)
        {
            Text = text;
            Answers = answers;
            ID = id;
        }
    }
}
