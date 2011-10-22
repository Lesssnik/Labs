using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumyantsev.Lab2.Railroad
{
    public class Timetable
    {
        /// <summary>
        /// Type of frequency
        /// </summary>
        public enum TypeOfFrequency : int
        {
            AllDays = 0,
            OnlyWeekend = 1,
            OnlySunday = 2
        }

        private Station FirstStation;

        private Station LastStation;

        public TimeSpan TimeOfArrival
        {
            get;
            private set;
        }

        public TimeSpan TimeOfDeparture
        {
            get;
            private set;
        }

        private TypeOfFrequency Type;

        /// <summary>
        /// Constructor with parametrs
        /// </summary>
        /// <param name="first">First station of train`s route</param>
        /// <param name="last">Last station of train`s route</param>
        /// <param name="time">Arrival time</param>
        /// <param name="tof">Type of frequency</param>
        public Timetable(Train train, TimeSpan time1, TimeSpan time2, int tof)
        {
            try
            {
                if (tof < 0 || tof > 1)
                    throw new ArgumentOutOfRangeException("type of farrival");
                FirstStation = train.FirstStation;
                LastStation = train.LastStation;
                TimeOfArrival = time1;
                TimeOfDeparture = time2;
                Type = (TypeOfFrequency)tof;
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Convert information about timetable to string format
        /// </summary>
        /// <returns>String format of information about station</returns>
        public override string ToString()
        {
            string str = "";
            str += FirstStation.Name + " - " + LastStation.Name + " | " + TimeOfArrival.ToString() + " - " + TimeOfDeparture.ToString() + " | " + Type;
            return str;
        }
    }
}
