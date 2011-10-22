using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumyantsev.Lab2.Railroad
{
    public class Railroad : IEnumerable<Station>, IDisposable
    {
        private List<Station> stations;

        /// <summary>
        /// Name of railroad
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// First station
        /// </summary>
        public Station FirstStation
        {
            get;
            private set;
        }

        /// <summary>
        /// Last station
        /// </summary>
        public Station LastStation
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor, that create new railroad
        /// </summary>
        public Railroad(string name, Station first, Station last)
        {
            stations = new List<Station>();
            Name = name;
            FirstStation = first;
            LastStation = last;
            stations.Add(first);
            stations.Add(last);
        }

        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns>IEnumerator</returns>
        public IEnumerator<Station> GetEnumerator()
        {
            return stations.GetEnumerator();
        }

        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Add new station to the railroad
        /// </summary>
        /// <param name="st">Station</param>
        public void AddStation(Station st, int position)
        {
            try
            {
                if (position != 1 && position != (stations.Count - 1))
                    stations.Insert(position - 1, st);
                else throw new ArgumentException("For adding first or last station use special functions");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Change first station
        /// </summary>
        /// <param name="st">New first station</param>
        public void AddFirstStation(Station st)
        {
            try
            {
                if (st.Track >= 2)
                {
                    stations.Insert(0, st);
                }
                else throw new Exception("First station must have more then 2 tracks");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Change last station
        /// </summary>
        /// <param name="st">New last station</param>
        public void AddLastStation(Station st)
        {
            try
            {
                if (st.Track >= 2)
                {
                    stations.Add(st);
                }
                else throw new Exception("Last station must have more then 2 tracks");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Delete station from railroad
        /// </summary>
        /// <param name="st">Station</param>
        public void DeleteStation(Station st)
        {
            stations.Remove(st);
        }

        /// <summary>
        /// Convert information about railroad to string format
        /// </summary>
        /// <returns>String format of information about railroad</returns>
        public override string ToString()
        {
            string str = "";
            foreach (Station st in stations)
            {
                str += st.ToString() + '\n';
            }
            return str;
        }

        /// <summary>
        /// Property, that return station with max track
        /// </summary>
        public double MaxTrack
        {
            get
            {
                return stations.Max<Station>(p => p.Track);
            }
        }

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Station> Filter(Func<Station, bool> predicate)
        {
            return stations.Where(predicate);
        }
        
         /// <summary>
        /// "Dispose" for railroad
        /// </summary>
        public void Dispose()
        {
        	Console.WriteLine("Dispose for railroad");
        }
    }
}