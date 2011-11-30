using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Rumyantsev.Lab2.Railroad;

namespace Rumyantsev.Lab4.XMLAndSerialization
{
    /// <summary>
    /// Save and load xml document with LINQ 
    /// </summary>
    class LINQXML
    {
        /// <summary>
        /// Create xml document from information about railroad
        /// </summary>
        /// <param name="railroad">Railroad</param>
        /// <returns>XML Document</returns>
        public XDocument SaveRailroad(Railroad railroad)
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("Railroad");
            doc.AddFirst(root);

            root.Add(new XAttribute("Name", railroad.Name));
            root.Add(new XAttribute("FirstStation", railroad.FirstStation.Name));
            root.Add(new XAttribute("LastStation", railroad.LastStation.Name));
            
            foreach (Station st in railroad)
                root.Add(SaveStation(st));

            return doc;
        }
        /// <summary>
        /// Create xml document from information about station
        /// </summary>
        /// <param name="station">Station</param>
        /// <returns>XML Element</returns>
        public XElement SaveStation(Station station)
        {
            XElement st = new XElement("Station");
            st.Add(new XAttribute("Name", station.Name), new XAttribute("Track", station.Track));

            XElement timetable = null;
            foreach (Timetable tt in station)
            {
                timetable = new XElement("TimeTable");
                timetable.Add(
                    new XAttribute("FirstStation", tt.FirstStation),
                    new XAttribute("LastStation", tt.LastStation),
                    new XAttribute("TimeOfArrival", tt.TimeOfArrival.ToString()),
                    new XAttribute("TimeOfDeparture", tt.TimeOfDeparture.ToString()),
                    new XAttribute("FreqType", tt.FreqType));

                if (timetable != null)
                    st.Add(timetable);
            }
            return st;
        }

        /// <summary>
        /// Create railroad from xml document
        /// </summary>
        /// <param name="document">XDocument</param>
        /// <returns>Railroad</returns>
        public Railroad LoadRailroad(XDocument document)
        {
            string Name = document.Root.Attribute("Name").Value;

            List<XElement> list = new List<XElement>();
            foreach (XElement obj in document.Root.Elements())
                list.Add(obj);

            return new Railroad(Name, LoadStation(list[0]), LoadStation(list[list.Count - 1]));
        }

        /// <summary>
        /// Create station from xml element
        /// </summary>
        /// <param name="document">XElement</param>
        /// <returns>Station</returns>
        public Station LoadStation(XElement element)
        {
            Station station = null;

            string Name = element.Attribute("Name").Value;
            int Track = int.Parse(element.Attribute("Track").Value);

            List<XElement> list = new List<XElement>();
            foreach (XElement obj in element.Elements())
                 list.Add(obj);
   
            station = new Station(Name, Track);

            foreach (XElement tt in list)
            {
                string FirstStation = tt.Attribute("FirstStation").Value;
                string LastStation = tt.Attribute("LastStation").Value;
                TimeSpan TimeOfArrival = TimeSpan.Parse(tt.Attribute("TimeOfArrival").Value);
                TimeSpan TimeOfDeparture = TimeSpan.Parse(tt.Attribute("TimeOfDeparture").Value);
                string StringFreqType = tt.Attribute("FreqType").Value;
                int FreqType = 0;
                switch (StringFreqType)
                {
                    case "AllDays":
                        FreqType = 0;
                        break;
                    case "OnlyWeekend":
                        FreqType = 1;
                        break;
                    case "OnlySunday":
                        FreqType = 2;
                        break;
                }
                station.AddTimetable(new Timetable(FirstStation, LastStation, TimeOfArrival, TimeOfDeparture, FreqType));    
            }

            return station;
        }
    }
}
