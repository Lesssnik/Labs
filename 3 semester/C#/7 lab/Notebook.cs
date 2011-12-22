using System;

namespace Rumyantsev.Lab7.Patterns
{
    class Notebook : IComputer
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

        public Notebook()
        {
            VideoCount = 0;
            RAMCount = 0;
            HDDCapacity = 0;
            ID = "";
        }

        public Notebook(byte VideoCount, byte RAMCount, long HDDCapacity)
        {
            this.VideoCount = VideoCount;
            this.RAMCount = RAMCount;
            this.HDDCapacity = HDDCapacity;
            ID = Singleton.Instance.Generate(this);
        }
    }
}
