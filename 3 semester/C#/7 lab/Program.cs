using System;

namespace Rumyantsev.Lab7.Patterns
{
    class Program
    {
        static void Main()
        {
            FactoryMethod method = new FactoryMethod();
            PC comp = (PC)method.CreateComputer(true, 2, 4, 1500);
            AbstractFactory<PC> factory = new AbstractFactory<PC>();
            PC pc = factory.Create(1, 1, 250);
            AbstractFactory<Notebook> factory2 = new AbstractFactory<Notebook>();
            Notebook notebook = factory2.Create(2, 3, 2000);
        }
    }
}
