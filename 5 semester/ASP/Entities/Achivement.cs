using System;

namespace Entities
{
    public class Achivement
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Description {get;set;}

        public string ImagePath { get; set; }
       
        public Achivement()
        {
            Title = "";
            Description = "";
            ImagePath = "";
        }

        public Achivement(string title, string description, string imagePath)
        {
            Title = title;
            Description = description;
            ImagePath = imagePath;
            ID = Guid.NewGuid();
        }

        public Achivement(Guid id, string title, string description, string imagePath)
        {
            Title = title;
            Description = description;
            ImagePath = imagePath;
            ID = id;
        }
    }
}