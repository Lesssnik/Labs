using System;
using System.Xml.Linq;

namespace Rumyantsev.Lab7.Patterns
{
    class XmlFile 
    {
        public void SaveComputer(string Path, PC computer)
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("Computer");
            root.Add(new XElement("ID", computer.ID));
            root.Add(new XElement("VideoCount", computer.VideoCount));
            root.Add(new XElement("RAMCount", computer.RAMCount));
            root.Add(new XElement("HDDCapacity", computer.HDDCapacity));
            doc.AddFirst(root);
            doc.Save(Path);
        }

        public PC LoadComputer(string Path)
        {
            try
            {
                XDocument doc = XDocument.Load(Path);
                string ID = doc.Root.Element("ID").Value;
                byte VideoCount = byte.Parse(doc.Root.Element("VideoCount").Value);
                byte RAMCount = byte.Parse(doc.Root.Element("RAMCount").Value);
                long HDDCapacity = long.Parse(doc.Root.Element("HDDCapacity").Value);
                return new PC(ID, VideoCount, RAMCount, HDDCapacity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
