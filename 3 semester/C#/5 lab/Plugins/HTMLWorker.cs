using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using PluginHelper;

namespace LesnikPlugins
{
    [PluginHelper("HTMLWorker", "Lesnik")]
    class HTMLWorker : IPlugin
    {
        private XDocument document;

        public HTMLWorker()
        {
            document = new XDocument();
        }

        public void CreateNewDocument()
        {
            Console.Write("Input title: ");
            string title = Console.ReadLine();
            document.AddFirst(new XElement("html"));
            document.Root.Add(new XElement("head"), new XElement("title", title));
            document.Root.Add(new XElement("body"));
        }

        public string WriteResult()
        {
            return document.ToString();
        }
    }
}
