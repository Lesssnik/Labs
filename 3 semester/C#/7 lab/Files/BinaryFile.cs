using System;
using System.IO;

namespace Rumyantsev.Lab7.Patterns
{
    class BinaryFile
    {
        public void SaveComputer(string Path, PC computer)
        {
            FileStream fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(computer.ID);
            bw.Write(computer.VideoCount);
            bw.Write(computer.RAMCount);
            bw.Write(computer.HDDCapacity);
            bw.Close();
            fs.Close();
        }

        public PC LoadComputer(string Path)
        {
            try
            {
                FileStream fs = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                string ID = br.ReadString();
                byte VideoCount = br.ReadByte();
                byte RAMCount = br.ReadByte();
                long HDDCapacity = br.ReadInt64();
                br.Close();
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
