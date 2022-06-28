using System;

namespace task09
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            double volume = length * width * height;
            double volumeL = volume * 0.001;
            Console.WriteLine(volumeL * (1 - (percentage / 100)));

        }
    }
}
