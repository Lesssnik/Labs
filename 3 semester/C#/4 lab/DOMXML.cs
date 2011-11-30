using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Rumyantsev.Lab2.Railroad;

namespace Rumyantsev.Lab4.XMLAndSerialization
{
    /// <summary>
    /// Save and load xml document with DOM model
    /// </summary>
    class DOMXML
    {
        private XmlDocument xmldoc;

        /// <summary>
        /// Create xml document from information about railroad
        /// </summary>
        /// <param name="railroad">Railroad</param>
        /// <returns>XML Document</returns>
        public XmlDocument SaveRailroad(Railroad railroad)
        {
            xmldoc = new XmlDocument();

            XmlElement root = xmldoc.CreateElement("Railroad");
            XmlAttribute rname = xmldoc.CreateAttribute("Name");
            rname.Value = railroad.Name;
            root.Attributes.Append(rname);

            root.SetAttribute("FirstStation", railroad.FirstStation.Name);
            root.SetAttribute("LastStation", railroad.LastStation.Name);

            foreach (var st in railroad)
                root.AppendChild(SaveStation(st));
            
            xmldoc.AppendChild(root);
            return xmldoc;
        }

        /// <summary>
        /// Create xml document from information about station
        /// </summary>
        /// <param name="station">Station</param>
        /// <returns>XML Element</returns>
        public XmlElement SaveStation(Station station)
        {
            XmlElement elem = xmldoc.CreateElement("Station");

            elem.SetAttribute("Name", station.Name);
            elem.SetAttribute("Track", station.Track.ToString());

            foreach (var tt in station)
                elem.AppendChild(SaveTimetable(tt));

            return elem;
        }

        /// <summary>
        /// Create xml document from information about timetable
        /// </summary>
        /// <param name="timetable">Timetable</param>
        /// <returns>XML Element</returns>
        public XmlElement SaveTimetable(Timetable timetable)
        {
            XmlElement elem = xmldoc.CreateElement("Timetable");

            elem.SetAttribute("FirstStation", timetable.FirstStation);
            elem.SetAttribute("LastStation", timetable.LastStation);
            elem.SetAttribute("TimeOfArrival", timetable.TimeOfArrival.ToString());
            elem.SetAttribute("TimeOfDeparture", timetable.TimeOfDeparture.ToString());
            int tot = 0;
            switch (timetable.FreqType)
                {
                    case Timetable.TypeOfFrequency.AllDays:
                    {
                        tot = 0;
                        break;
                    }
                    case Timetable.TypeOfFrequency.OnlyWeekend:
                    {
                        tot = 1;
                        break;
                    }
                    case Timetable.TypeOfFrequency.OnlySunday:
                    {
                        tot = 2;
                        break;
                    }
                }
            elem.SetAttribute("FreqType", tot.ToString());

            return elem;
        }

        /// <summary>
        /// Load information about railroad from xml document
        /// </summary>
        /// <param name="document">XML Document</param>
        /// <returns>Railroad</returns>
        public Railroad LoadRailroad(XmlDocument document)
        {
            XmlElement root = document.FirstChild as XmlElement;
            string Name = root.Attributes["Name"].Value;

            List<Station> list = new List<Station>();
            foreach (XmlElement elem in root.ChildNodes)
                list.Add(LoadStation(elem));

            return new Railroad(Name, list[0], list[list.Count - 1]);
        }

        /// <summary>
        /// Load information about station from xml element
        /// </summary>
        /// <param name="element">XML Element</param>
        /// <returns>Station</returns>
        public Station LoadStation(XmlElement element)
        {
            Station station = null;

            string Name = element.Attributes["Name"].Value;
            int Track = int.Parse(element.Attributes["Track"].Value);

            List<Timetable> list = new List<Timetable>();
            foreach (XmlElement elem in element.ChildNodes)
                list.Add(LoadTimetable(elem));

            station = new Station(Name, Track);

            foreach (Timetable tt in list)
                station.AddTimetable(tt);

            return station;
        }

        /// <summary>
        /// Load information about timetable from xml element
        /// </summary>
        /// <param name="element">XML Element</param>
        /// <returns>Timetable</returns>
        public Timetable LoadTimetable(XmlElement element)
        {
            string FirstStation = element.Attributes["FirstStation"].Value;
            string LastStation = element.Attributes["LastStation"].Value;
            TimeSpan TimeOfArrival = TimeSpan.Parse(element.Attributes["TimeOfArrival"].Value);
            TimeSpan TimeOfDeparture = TimeSpan.Parse(element.Attributes["TimeOfDeparture"].Value);
            int FreqType = int.Parse(element.Attributes["FreqType"].Value);

            return new Timetable(FirstStation, LastStation, TimeOfArrival, TimeOfDeparture, FreqType);
        }
    }
}
