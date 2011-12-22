using System;

namespace Rumyantsev.Lab7.Patterns
{
    class AbstractFactory<TComputer> where TComputer : IComputer, new()
    {
        public TComputer Create(byte VideoCount, byte RAMCount, long HDDCapacity)
        {
            Factory<TComputer> factory = new Factory<TComputer>();
            TComputer computer = (TComputer)factory.CreateComputer(VideoCount, RAMCount, HDDCapacity);
            return computer;
        }
    }
}
