using System;
namespace Entities
{
    public class Answer
    {
        public Guid ID { get; set; }

        public string Text { get; set; }

        public bool IsTrue { get; set; }

        public Answer()
        {
            Text = "";
            IsTrue = false;
            ID = Guid.NewGuid();
        }

        public Answer(string text, bool isTrue)
        {
            Text = text;
            IsTrue = isTrue;
            ID = Guid.NewGuid();
        }

        public Answer(string text, bool isTrue, Guid id)
        {
            Text = text;
            IsTrue = isTrue;
            ID = id;
        }
    }
}
