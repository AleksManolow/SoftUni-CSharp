using System;
using System.Collections.Generic;
using System.Linq;

namespace task01_Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capasity = int.Parse(Console.ReadLine());
            string comand = Console.ReadLine();
            while (comand != "end")
            {
                string[] c = comand.Split();

                if (c[0] == "Add")
                {
                    wagons.Add(int.Parse(c[1]));
                }
                else
                {
                    int number = int.Parse(c[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + number <= capasity)
                        {
                            wagons[i] += number;
                            break;
                        }
                    }
                }
                comand = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
