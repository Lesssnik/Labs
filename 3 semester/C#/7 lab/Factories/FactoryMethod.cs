using System;

namespace Rumyantsev.Lab7.Patterns
{
    class FactoryMethod : IFactoryMethod
    {
        public IComputer CreateComputer(bool isPC, byte VideoCount, byte RAMCount, long HDDCapacity)
        {
            if (isPC == true)
                return new PC(VideoCount, RAMCount, HDDCapacity);
            return new Notebook(VideoCount, RAMCount, HDDCapacity);
        }
    }
}
