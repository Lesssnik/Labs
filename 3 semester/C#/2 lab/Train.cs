using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumyantsev.Lab2.Railroad
{
	public class Train : IDisposable
    {
        private Station stations;

        private TypeOfTrain type;

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
        /// <param name="st">The station is located on the train.</param>
        /// <param name="t">Number of tracks</param>
        public Train(Station st, int w, int num, int tot)
        {
            try
            {
                if (w <= 0)
                    throw new Exception("Error: you can`t create train without wagons");
                if (tot < 0 || tot > 4)
                    throw new ArgumentOutOfRangeException("type of train");
                stations = st;
                Wagon = w;
                Number = num;
                type = (TypeOfTrain)tot;
                stations.AddTrain(this);
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
        /// Change station
        /// </summary>
        /// <param name="st">The station, which should transfer train.</param>
        public void ChangeStation(Station st)
        {
            this.stations.DeleteTrain(this);
            stations = st;
            stations.AddTrain(this);
        }

        /// <summary>
        /// Convert information about railroad to string format
        /// </summary>
        /// <returns>String format of information about railroad</returns>
        public override string ToString()
        {
            return "Number of wagons: " + Wagon + "; Train number: " + Number + "; Type of train: " + type;
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