using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Rumyantsev.Lab2.Railroad;
using Rumyantsev.Lab4.XMLAndSerialization.Serialization;

namespace Rumyantsev.Lab4.XMLAndSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Station st1 = new Station("Минск", 6);
            Timetable table = new Timetable("Минск-Пассажирский", "Бобруйск", new TimeSpan(4, 6, 2), new TimeSpan(16, 4, 7), 0);
            Timetable table2 = new Timetable("Минск-Пассажирский", "Коханово", new TimeSpan(1, 54, 52), new TimeSpan(1, 51, 0), 1);
            Timetable table3 = new Timetable("Вильнюс", "Лида", new TimeSpan(16, 0, 0), new TimeSpan(5, 1, 9), 0);
            Timetable table4 = new Timetable("Лесная", "Борисов", new TimeSpan(0, 0, 0), new TimeSpan(1, 0, 0), 0);
            Timetable table5 = new Timetable("Пхов", "Брест", new TimeSpan(14, 35, 0), new TimeSpan(23, 53, 10), 1);
            st1.AddTimetable(table);
            st1.AddTimetable(table2);
            st1.AddTimetable(table3);
            st1.AddTimetable(table4);
            st1.AddTimetable(table5);

            new LINQHTML().SaveTimetables(@"D:\index.html", st1);
        }
    }
}
