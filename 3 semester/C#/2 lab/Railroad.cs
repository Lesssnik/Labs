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
        /// Constructor, that create new collection of stations
        /// </summary>
        public Railroad(string name)
        {
            stations = new List<Station>();
            Name = name;
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
        public void AddStation(Station st)
        {
            if (!(stations.Exists(p => p == st)))
                stations.Add(st);
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