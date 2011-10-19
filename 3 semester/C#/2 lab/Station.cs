using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumyantsev.Lab2.Railroad
{
    public class Station : IEnumerable<Train>, IDisposable
    {
        private List<Train> trains;

        private Railroad railroads; 

        /// <summary>
        /// Name of station
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Number of tracks
        /// </summary>
        public int Track
        {
            get;
            private set;
        }

        /// <summary>
        /// Count
        /// </summary>
        public int Count
        {
            get
            {
                return trains.Count;
            }
        }

        /// <summary>
        /// Constructor with parametrs
        /// </summary>
        /// <param name="r">Railroad, that contain station</param>
        /// <param name="name">Name of station</param>
        /// <param name="tr">Number of tracks</param>
        public Station(Railroad r, string name, int tr)
        {
            railroads = r;
            Name = name;
            Track = tr;
            trains = new List<Train>();
            railroads.AddStation(this);
        }

        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns>IEnumerator</returns>
        public IEnumerator<Train> GetEnumerator()
        {
            return trains.GetEnumerator();
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
        /// Add train to the station
        /// </summary>
        /// <param name="t">Train</param>
        public void AddTrain(Train t)
        {
            try
            {
                if (trains.Count + 1 > Track)
                    throw new Exception("Error: there is no more free tracks in this station");
                trains.Add(t);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Delete train from station
        /// </summary>
        /// <param name="tr">Train</param>
        public void DeleteTrain(Train tr)
        {
            trains.Remove(tr);
        }

        /// <summary>
        /// Convert information about station to string format
        /// </summary>
        /// <returns>String format of information about station</returns>
        public override string ToString()
        {
            string str = "";
            str += "Name: " + Name + "; Number of tracks: " + Track + '\n';

            foreach (Train tr in trains)
            {
                str += tr.ToString() + '\n';
            }
            return str;
        }

        /// <summary>
        /// Property, that return average load of paths
        /// </summary>
        public double AverageHard
        {
            get
            {
                return ((double)Count / (double)Track); 
            }
        }

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Train> Filter(Func<Train, bool> predicate)
        {
            return trains.Where(predicate);
        }
        
        /// <summary>
        /// "Dispose" for station
        /// </summary>
        public void Dispose()
        {
        	Console.WriteLine("Dispose for station");
        }
    }
}