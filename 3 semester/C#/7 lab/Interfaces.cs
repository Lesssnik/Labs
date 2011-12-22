using System;

namespace Rumyantsev.Lab7.Patterns
{
    public interface IFactoryMethod
    {
        IComputer CreateComputer(bool isPC, byte VideoCount, byte RAMCount, long HDDCapacity);
    }

    public interface IAbstractFactory
    {
        IComputer CreateComputer(byte VideoCount, byte RAMCount, long HDDCapacity);
    }

    public interface IComputer
    {
        string ID
        { get; }

        byte VideoCount
        { get; }

        byte RAMCount
        { get; }

        long HDDCapacity
        { get; }
    }
}
