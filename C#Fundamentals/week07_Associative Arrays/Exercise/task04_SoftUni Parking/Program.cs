using System;
using System.Collections.Generic;

namespace task04_SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> cars = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "register")
                {
                    if (!cars.ContainsKey(input[1]))
                    {
                        cars.Add(input[1], input[2]);
                        Console.WriteLine($"{input[1]} registered {input[2]} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {input[2]}");
                    }
                }
                else if (input[0] == "unregister")
                {
                    if (cars.ContainsKey(input[1]))
                    {
                        cars.Remove(input[1]);
                        Console.WriteLine($"{input[1]} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {input[1]} not found");
                    }

                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
