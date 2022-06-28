using System;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int available = width * length * height;
            string input = "";
            while(input != "Done" && available > 0)
            {
                input = Console.ReadLine();
                if (input != "Done")
                {
                    available -= (int.Parse(input));
                }
            }
            if (available >= 0)
                Console.WriteLine($"{available} Cubic meters left.");
            else
                Console.WriteLine($"No more free space! You need {Math.Abs(available)} Cubic meters more.");
        }
    }
}
