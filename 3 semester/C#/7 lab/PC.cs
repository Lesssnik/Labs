using System;

namespace Rumyantsev.Lab7.Patterns
{
    public class PC : IComputer
    {
        public string ID
        {
            get;
            private set;
        }

        public byte VideoCount
        {
            get;
            private set;
        }

        public byte RAMCount
        {
            get;
            private set;
        }

        public long HDDCapacity
        {
            get;
            private set;
        }

        public PC()
        {
            ID = "";
            VideoCount = 0;
            RAMCount = 0;
            HDDCapacity = 0;
        }

        public PC(byte VideoCount, byte RAMCount, long HDDCapacity)
        {
            this.VideoCount = VideoCount;
            this.RAMCount = RAMCount;
            this.HDDCapacity = HDDCapacity;
            ID = Singleton.Instance.Generate(this);
        }

        public PC(string ID, byte VideoCount, byte RAMCount, long HDDCapacity)
        {
            this.ID = ID;
            this.VideoCount = VideoCount;
            this.RAMCount = RAMCount;
            this.HDDCapacity = HDDCapacity;
        }
    }
}
