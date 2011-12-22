using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumyantsev.Lab7.Patterns
{
    public sealed class Singleton
    {
        private Singleton() { }
        static Singleton() { }
        private static readonly Singleton uniqueInstance = new Singleton();
        public static Singleton Instance
        {
            get { return uniqueInstance; }
        }
        public string Generate(object obj)
        {
            return obj.GetHashCode().ToString();
        }
    }

}
