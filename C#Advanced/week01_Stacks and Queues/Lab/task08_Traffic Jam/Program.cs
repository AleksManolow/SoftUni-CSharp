using System;
using System.Collections.Generic;

namespace task08_Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> vehicles = new Queue<string>();
            string input = Console.ReadLine();
            int totalCarsPassed = 0;
            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < n && vehicles.Count > 0; i++)
                    {
                        Console.WriteLine($"{vehicles.Dequeue()} passed!");
                        totalCarsPassed++;
                    }
                }
                else
                {
                    vehicles.Enqueue(input);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
        }
    }
}
