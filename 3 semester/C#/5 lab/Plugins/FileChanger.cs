using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PluginHelper;

namespace FileChanger
{
    [PluginHelper("FileChanger", "Lesnik")]
    class FileChanger : IPlugin
    {
        private static string text = "";

        public FileChanger()
        {
        }

        public string WriteResult()
        {
            return text;
        }

        public static void NumbersToString(string Path)
        {
            FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.ReadWrite);
            text = "";
            for (int i = 0; i < fs.Length; i++)
            {
                char c = (char)fs.ReadByte();
                if (!char.IsDigit(c))
                    text += c;
                else
                {
                    switch (c)
                    {
                        case '0':
                            text += "zero";
                            break;
                        case '1':
                            text += "one";
                            break;
                        case '2':
                            text += "two";
                            break;
                        case '3':
                            text += "three";
                            break;
                        case '4':
                            text += "four";
                            break;
                        case '5':
                            text += "five";
                            break;
                        case '6':
                            text += "six";
                            break;
                        case '7':
                            text += "seven";
                            break;
                        case '8':
                            text += "eight";
                            break;
                        case '9':
                            text += "nine";
                            break;
                    }
                }
            }
            fs.Seek(0, SeekOrigin.Begin);
            foreach (char c in text)
                fs.WriteByte((byte)c);
            fs.Close();
        }
    }
}
