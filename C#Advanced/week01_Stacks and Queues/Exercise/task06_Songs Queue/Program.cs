using System;
using System.Collections.Generic;

namespace task06_Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] listOfSongs = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(listOfSongs);
            while (songs.Count > 0)
            {
                string command = Console.ReadLine();
                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    if (songs.Contains(command.Substring(4)))
                    {
                        Console.WriteLine($"{command.Substring(4)} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(command.Substring(4));
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
