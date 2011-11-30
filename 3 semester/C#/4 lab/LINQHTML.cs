using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Rumyantsev.Lab2.Railroad;

namespace Rumyantsev.Lab4.XMLAndSerialization
{
    /// <summary>
    /// Save station`s timetable as html document
    /// </summary>
    class LINQHTML
    {
        /// <summary>
        /// Create html file with information about timetable and save it
        /// </summary>
        /// <param name="Path">Where html file should be saved</param>
        /// <param name="station">Station</param>
        public void SaveTimetables(string Path, Station station)
        {
            FileStream fs = new FileStream(Path, FileMode.Create);

            XDocument document = new XDocument();
            document.AddFirst(new XElement("html"));

            document.Root.Add(new XElement("head", 
                new XElement("title", station.Name)));
            
            XElement body = new XElement("body");
            XElement div = new XElement("div");
            foreach (Timetable tt in station)
            {
                XElement inner = new XElement("div", new XAttribute("style", "width:800px;"));
                inner.Add(new XElement("div", tt.FirstStation + " - " + tt.LastStation, new XAttribute("style", "border:solid; float:left; width:400px; heigth:20px;"), new XAttribute("align", "center")),
                    new XElement("div", tt.TimeOfArrival.ToString() + " - " + tt.TimeOfDeparture.ToString(), new XAttribute("style", "border:solid; float:left; width:150px; heigth:20px;"), new XAttribute("align", "center")),
                    new XElement("div", tt.FreqType, new XAttribute("style", "border:solid; float:left; width:150px; heigth:20px;"), new XAttribute("align", "center")),
                    new XElement("br"));
                div.Add(inner);
            }
            body.Add(div);
            document.Root.Add(body);

            document.Save(fs);
            fs.Close();
        }
    }
}
