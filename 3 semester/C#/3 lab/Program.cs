using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Rumyantsev.Lab2.Railroad;
using System.Security.Cryptography;

namespace Rumyantsev.Lab3.Files
{
    class Program
    {
        static void Main(string[] args)
        {
            Station st1 = new Station("Station1", 6);
            Station st2 = new Station("Station2", 2);
            Railroad r1 = new Railroad("Railroad1", st1, st2);
            TimeSpan time1 = new TimeSpan(9, 3, 0);
            TimeSpan time2 = new TimeSpan(18, 7, 10);
            Timetable table = new Timetable("1", "2", time1, time2, 0);
            st1.AddTimetable(table);

            // Для зашифрованного файла
            /*Rijndael RijndaelAlg = Rijndael.Create();
            CryptoFileWorking cfw = new CryptoFileWorking();

            FileStream fs1 = File.OpenWrite(@"D:\1.zip");
            cfw.SaveCryptoRailroad(r1, fs1, RijndaelAlg.Key, RijndaelAlg.IV);
            fs1.Close();
            FileStream fs2 = File.OpenRead(@"D:\1.zip");
            Railroad railroad = cfw.LoadCryptoRailroad(fs2, RijndaelAlg.Key, RijndaelAlg.IV);
            fs2.Close();*/

            // Для обычного файла
            /*TextFileWorking t = new TextFileWorking();
            FileStream fs1 = File.OpenWrite(@"D:\1.tbl");
            t.SaveRailroad(fs1, r1);

            TextFileWorking t1 = new TextFileWorking();
            FileStream fs2 = File.OpenRead(@"D:\1.tbl");
            Railroad railroad = t1.LoadRailroad(fs2);*/
        }
    }
}
