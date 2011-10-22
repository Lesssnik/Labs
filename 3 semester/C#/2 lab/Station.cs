using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumyantsev.Lab2.Railroad
{
    public class Station : IEnumerable<Timetable>, IDisposable
    {
        private List<Timetable> Timetable;

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
        /// Constructor with parametrs
        /// </summary>
        /// <param name="r">Railroad, that contain station</param>
        /// <param name="name">Name of station</param>
        /// <param name="tr">Number of tracks</param>
        public Station(string name, int track)
        {
            Timetable = new List<Timetable>();
            Name = name;
            Track = track;
        }

        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns>IEnumerator</returns>
        public IEnumerator<Timetable> GetEnumerator()
        {
            return Timetable.GetEnumerator();
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
        /// Complementing the station timetable
        /// </summary>
        /// <param name="table">Element of timetable</param>
        public void AddTimetable(Timetable table)
        {
            Timetable.Add(table);
            Timetable.Sort(delegate(Timetable t1, Timetable t2){return t1.TimeOfArrival.CompareTo(t2.TimeOfArrival);});
        }

        /// <summary>
        /// Remove some element from timetable
        /// </summary>
        /// <param name="table">Element, that should be removed</param>
        public void DeleteTimetable(Timetable table)
        {
            Timetable.Remove(table);
        }

        /// <summary>
        /// Change element of timetable
        /// </summary>
        /// <param name="table">New element</param>
        /// <param name="position">Position of old element</param>
        public void ChangeTimetable(Timetable table, int position)
        {
            Timetable[position - 1] = table;
        }

        /// <summary>
        /// Convert information about station to string format
        /// </summary>
        /// <returns>String format of information about station</returns>
        public override string ToString()
        {
            string str = "";
            str += "Name: " + Name + "\nNumber of tracks: " + Track + '\n';

            foreach (Timetable tt in Timetable)
            {
                str += tt.ToString() + '\n';
            }
            return str;
        }

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Timetable> Filter(Func<Timetable, bool> predicate)
        {
            return Timetable.Where(predicate);
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