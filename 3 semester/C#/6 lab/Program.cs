using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rumyantsev.Lab6.Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = "", title = "";
            int index;
            List<Playlist> list = new List<Playlist>();

            Console.WriteLine(@"Load - load playlist
Start - start playing
Pause - pause
Continue - continue
Stop - stop playing
Info - print information about playlist
Exit - exit
~~~~~~~~~~~~~~");

            while (cmd != "Exit")
            {
                Console.Title = "";
                title = "Now playing: ";
                foreach (Playlist p in list)
                {
                    if (p.thread != null)
                        if (p.thread.IsAlive == true)
                            if (p.isPaused == true)
                                title += p.Name + "(Paused); ";
                            else title += p.Name + "; ";
                }
                Console.Title = title;

                Console.Write("-> ");
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "Load":
                        Console.WriteLine("Input path to the playlist");
                        Playlist pl = File.LoadPlaylist(Console.ReadLine());
                        if (pl != null)
                        {
                            list.Add(pl);
                            Console.WriteLine("Playlist was add");
                        }
                        break;
                    case "Start":
                        WritePlaylists(list);
                        Console.WriteLine("Input number of playlist");
                        index = int.Parse(Console.ReadLine());
                        list[index - 1].Start();
                        break;
                    case "Pause":
                        WritePlaylists(list);
                        Console.WriteLine("Input number of playlist");
                        index = int.Parse(Console.ReadLine());
                        list[index - 1].Pause();
                        break;
                    case "Continue":
                        WritePlaylists(list);
                        Console.WriteLine("Input number of playlist");
                        index = int.Parse(Console.ReadLine());
                        list[index - 1].Continue();
                        break;
                    case "Stop":
                        WritePlaylists(list);
                        Console.WriteLine("Input number of playlist");
                        index = int.Parse(Console.ReadLine());
                        list[index - 1].Stop();
                        break;
                    case "Info":
                        foreach (Playlist p in list)
                            Console.WriteLine(p.ToString());
                        break;
                    case "Exit":
                        foreach (Playlist p in list)
                        {
                            p.Stop();
                        }
                        break;
                }
            }
        }

        private static void WritePlaylists(List<Playlist> list)
        {
            int i = 1;
            foreach (Playlist p in list)
            {
                Console.WriteLine(i + ") " + p.Name);
                i++;
            }
        }
    }
}
