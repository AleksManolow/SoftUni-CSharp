using System;
using System.Collections.Generic;

namespace task07_Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputPlayers = Console.ReadLine().Split(' ');
            Queue<string> players = new Queue<string>(inputPlayers);
            int n = int.Parse(Console.ReadLine());
            while (players.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    players.Enqueue(players.Dequeue());
                }
                Console.WriteLine($"Removed {players.Dequeue()}");
            }
            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
