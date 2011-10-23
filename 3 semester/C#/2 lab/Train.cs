using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumyantsev.Lab2.Railroad
{
    /// <summary>
    /// A class representing a train
    /// </summary>
	public class Train : IDisposable
    {
        /// <summary>
        /// First route station
        /// </summary>
        public string FirstStation
        {
            get;
            private set;
        }

        /// <summary>
        /// Last route station
        /// </summary>
        public string LastStation
        {
            get;
            private set;
        }

        /// <summary>
        /// Type of train
        /// </summary>
        private TypeOfTrain Type;

        /// <summary>
        /// Identify number of train
        /// </summary>
        public int Number
        {
            get;
            private set;
        }

        /// <summary>
        /// Number of wagons
        /// </summary>
        public int Wagon
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Type of train
        /// </summary>
        public enum TypeOfTrain : int
        {
            Freight = 0,
            Passenger = 1,
            Facilities = 2,
            Military = 3,
            Hospital = 4
        }

        /// <summary>
        /// Constructor with parametrs
        /// </summary>
        /// <param name="first">First route station</param>
        /// <param name="last">Last route station</param>
        /// <param name="w">Number of wagons</param>
        /// <param name="num">Train`s identify number</param>
        /// <param name="tot">Type of train</param>
        public Train(Station first, Station last, int w, int num, int tot)
        {
            try
            {
                if (w <= 0)
                    throw new Exception("Error: you can`t create train without wagons");
                if (tot < 0 || tot > 4)
                    throw new ArgumentOutOfRangeException("type of train");
                FirstStation = first.Name;
                LastStation = last.Name;
                Wagon = w;
                Number = num;
                Type = (TypeOfTrain)tot;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Convert information about railroad to string format
        /// </summary>
        /// <returns>String format of information about railroad</returns>
        public override string ToString()
        {
            return "Number of wagons: " + Wagon + "; Train number: " + Number + "; Type of train: " + Type;
        }
        
        /// <summary>
        /// "Dispose" for train
        /// </summary>
        public void Dispose()
        {
        	Console.WriteLine("Dispose for train");
        }
    }
}