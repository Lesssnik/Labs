using System;

namespace Rumyantsev.Lab7.Patterns
{
    class Factory<TComputer> : IAbstractFactory where TComputer : IComputer, new()
    {
        public IComputer CreateComputer(byte VideoCount, byte RAMCount, long HDDCapacity)
        {
            if (typeof(TComputer) == typeof(PC))
                return new PC(VideoCount, RAMCount, HDDCapacity);
            else return new Notebook(VideoCount, RAMCount, HDDCapacity);
        }
    }
}
