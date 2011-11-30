using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginHelper
{
    public interface IPlugin
    {
        string WriteResult();
    }

    public class PluginHelperAttribute : Attribute
    {
        private string Name;
        private string Author;
        private DateTime CreationTime;

        public PluginHelperAttribute(string name, string author)
        {
            Name = name;
            Author = author;
            CreationTime = DateTime.Now;
        }
    }
}