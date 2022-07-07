using System;
using System.Collections.Generic;

namespace task03_Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> songs = new List<Song>();
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                Song song = new Song();
                string[] input = Console.ReadLine().Split('_');
                song.TypeName = input[0];
                song.Name = input[1];
                song.Time = input[2];

                songs.Add(song);
            }
            string typeName = Console.ReadLine();
            if (typeName == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (var song in songs)
                {
                    if (song.TypeName == typeName)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }

        }
    }
    public class Song
    {
        public string TypeName { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

    }
}
