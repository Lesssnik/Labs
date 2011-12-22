using System;
using System.IO;

namespace Rumyantsev.Lab7.Patterns
{
    class TextFile
    {
        public void SaveComputer(string Path, PC computer)
        {
            FileStream fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(computer.ID);
            sw.WriteLine(computer.VideoCount);
            sw.WriteLine(computer.RAMCount);
            sw.WriteLine(computer.HDDCapacity);
            sw.Close();
            fs.Close();
        }

        public PC LoadComputer(string Path)
        {
            try
            {
                FileStream fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string ID = sr.ReadLine();
                byte VideoCount = byte.Parse(sr.ReadLine());
                byte RAMCount = byte.Parse(sr.ReadLine());
                long HDDCapacity = long.Parse(sr.ReadLine());
                sr.Close();
                fs.Close();
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
