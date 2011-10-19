using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumyantsev.Lab2.Railroad
{
    class Program
    {
        static void Main(string[] args)
        {
            Railroad railroad1 = new Railroad("First_Railroad");
            Station station1 = new Station(railroad1, "First_Station", 5);
            Station station2 = new Station(railroad1, "Second_Station", 3);
            Station station3 = new Station(railroad1, "Third_Station", 4);
            Train train1 = new Train(station1, 5, 1407, 1);
            Train train2 = new Train(station1, 10, 1923, 2);
            Train train3 = new Train(station1, 15, 1012, 3);

            train2.ChangeStation(station2);

            Console.WriteLine(station1.ToString());
            Console.WriteLine(station2.ToString());
            Console.WriteLine("----------------------------------------------------");

            station1.DeleteTrain(train3);
            Console.WriteLine(station1.ToString());
            Console.WriteLine("----------------------------------------------------");

            Console.ReadLine();
        }
    }
}
