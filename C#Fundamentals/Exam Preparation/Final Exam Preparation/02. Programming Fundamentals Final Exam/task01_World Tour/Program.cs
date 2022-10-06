using System;

namespace task01_World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string[] input = Console.ReadLine().Split(':');
            while (input[0] != "Travel")
            {
                if (input[0] == "Add Stop" && int.Parse(input[1]) >= 0 && int.Parse(input[1]) < stops.Length)
                {
                    stops = stops.Substring(0, int.Parse(input[1])) + input[2] + stops.Substring(int.Parse(input[1]));
                }
                else if (input[0] == "Remove Stop" && int.Parse(input[1]) >= 0 && int.Parse(input[1]) < stops.Length
                    && int.Parse(input[2]) >= 0 && int.Parse(input[2]) < stops.Length)
                {
                    stops = stops.Remove(int.Parse(input[1]), int.Parse(input[2]) - int.Parse(input[1]) + 1);
                }
                else if (input[0] == "Switch")
                {
                    stops = stops.Replace(input[1], input[2]);
                }
                Console.WriteLine(stops);
                input = Console.ReadLine().Split(':');
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
