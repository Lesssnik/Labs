using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumyantsev.Lab2.Railroad
{
    /// <summary>
    /// Class representing a railway timetable`s element
    /// </summary>
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

        /// <summary>
        /// First train`s route station
        /// </summary>
        public string FirstStation
        {
            get;
            private set;
        }

        /// <summary>
        /// Last train`s route station
        /// </summary>
        public string LastStation
        {
            get;
            private set;
        }

        /// <summary>
        /// Time of train`s arrival
        /// </summary>
        public TimeSpan TimeOfArrival
        {
            get;
            private set;
        }

        /// <summary>
        /// Time of train`s departure
        /// </summary>
        public TimeSpan TimeOfDeparture
        {
            get;
            private set;
        }

        /// <summary>
        /// Type of frequency
        /// </summary>
        public TypeOfFrequency FreqType
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor with parametrs
        /// </summary>
        /// <param name="first">First station of train`s route</param>
        /// <param name="last">Last station of train`s route</param>
        /// <param name="time">Arrival time</param>
        /// <param name="tof">Type of frequency</param>
        public Timetable(string first, string last, TimeSpan time1, TimeSpan time2, int tof)
        {
            try
            {
                if (tof < 0 || tof > 1)
                    throw new ArgumentOutOfRangeException("type of farrival");
                FirstStation = first;
                LastStation = last;
                TimeOfArrival = time1;
                TimeOfDeparture = time2;
                FreqType = (TypeOfFrequency)tof;
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
            str += FirstStation + " - " + LastStation + " | " + TimeOfArrival.ToString() + " - " + TimeOfDeparture.ToString() + " | " + FreqType;
            return str;
        }
    }
}
