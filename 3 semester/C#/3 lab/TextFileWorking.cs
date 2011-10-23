using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rumyantsev.Lab2.Railroad;
using System.IO;

namespace Rumyantsev.Lab3
{
    /// <summary>
    /// Save and load information about the railroad, with the inclusion of their stations
    /// and timetables, information about the station and its timetable or  some timetable.
    /// </summary>
    public class TextFileWorking
    {
        /// <summary>
        /// Save information about railroad to the file
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="railroad">Railroad, that should be saved</param>
        public void SaveRailroad(Stream stream, Railroad railroad)
        {
            if (railroad != null)
            {
                BinaryWriter bw = new BinaryWriter(stream);
                bw.Write(railroad.Name);
                SaveStation(stream, railroad.FirstStation);
                SaveStation(stream, railroad.LastStation);

                bw.Write(railroad.Count);

                foreach (var station in railroad)
                {
                    SaveStation(stream, station);
                }
            }
            stream.Close();
        }

        /// <summary>
        /// Load information about railroad from file
        /// </summary>
        /// <param name="stream">Stream, that contains path to the file</param>
        /// <returns>Railroad</returns>
        public Railroad LoadRailroad(Stream stream)
        {
            BinaryReader br = new BinaryReader(stream);

            string name = br.ReadString();
            Station St1 = LoadStation(stream);
            Station St2 = LoadStation(stream);
            Railroad railroad = new Railroad(name, St1, St2);

            int stationCount = br.ReadInt32();
            for (int i = 0; i < stationCount; i++)
            {
                railroad.AddStation(LoadStation(stream),i);
            }
            br.Close();
            return railroad;
        }

        /// <summary>
        /// Save information about station to the file
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="station">Station, that should be saved</param>
        public void SaveStation(Stream stream, Station station)
        {
            if (station != null)
            {
                BinaryWriter bw = new BinaryWriter(stream);

                bw.Write(station.Name);
                bw.Write(station.Track);

                bw.Write(station.Count);
                foreach (var timetable in station)
                {
                    SaveTimetable(stream, timetable);
                }
            }
        }

        /// <summary>
        /// Load information about station from file
        /// </summary>
        /// <param name="stream">Stream, that contains path to the file</param>
        /// <returns>Station</returns>
        public Station LoadStation(Stream stream)
        {
            BinaryReader br = new BinaryReader(stream);

            string name = br.ReadString();
            int track = br.ReadInt32();
            Station station = new Station(name, track);

            int timetableCount = br.ReadInt32();
            for (int i = 0; i < timetableCount; i++)
            {
                station.AddTimetable(LoadTimetable(stream));
            }
            return station;
        }

        /// <summary>
        /// Save information about timetable to the file
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="timetable">Timetable, that should be saved</param>
        public void SaveTimetable(Stream stream, Timetable timetable)
        {
            if (timetable != null)
            {
                BinaryWriter bw = new BinaryWriter(stream);

                bw.Write(timetable.FirstStation);
                bw.Write(timetable.LastStation);
                bw.Write(timetable.TimeOfArrival.ToString());
                bw.Write(timetable.TimeOfDeparture.ToString());

                switch (timetable.FreqType)
                {
                    case Timetable.TypeOfFrequency.AllDays:
                    {
                        stream.WriteByte((byte)0);
                        break;
                    }
                    case Timetable.TypeOfFrequency.OnlyWeekend:
                    {
                        stream.WriteByte((byte)1);
                        break;
                    }
                    case Timetable.TypeOfFrequency.OnlySunday:
                    {
                        stream.WriteByte((byte)2);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Load information about timetable from file
        /// </summary>
        /// <param name="stream">Stream, that contains path to the file</param>
        /// <returns>Timetable</returns>
        public Timetable LoadTimetable(Stream stream)
        {
            BinaryReader br = new BinaryReader(stream);

            string firstStation = br.ReadString();
            string lastStation = br.ReadString();
            TimeSpan timeOfArrival = TimeSpan.Parse(br.ReadString());
            TimeSpan timeOfDeparture = TimeSpan.Parse(br.ReadString());
            int type = stream.ReadByte();

            Timetable timetable = new Timetable(firstStation, lastStation, timeOfArrival, timeOfDeparture, type);
            return timetable;
        }
    }
}
