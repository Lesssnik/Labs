using Entities;
using MongoDB;
using MongoDB.Linq;
using System.Collections.Generic;

namespace DAL
{
    public class Class1
    {
        void Test()
        {
            //Create a default mongo object. This handles our connections to the database.
            //By default, this will connect to localhost, 
            //port 27017 which we already have running from earlier.
            var mongo = new Mongo();
            mongo.Connect();

            //Get the blog database. If it doesn't exist, that's ok because MongoDB will create it 
            //for us when we first use it. Awesome!!!
            var db = mongo.GetDatabase("blog");

            //Get the Post collection. By default, we'll use
            //the name of the class as the collection name. Again,
            //if it doesn't exist, MongoDB will create it when we first use it.
            var collection = db.GetCollection<Test>();

            //this deletes everything out of the collection so we can run this over and over again.
            collection.Delete(p => true);

            //Create a Post to enter into the database.
            var test = new Test("Test1", null, Types.Programming, "Lesnik");

            //Save the post. This will perform an upsert. As in, if the post
            //already exists, update it, otherwise insert it.
            collection.Save(test);
        }
    }
}
