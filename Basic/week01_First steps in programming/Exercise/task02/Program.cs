using System;

namespace task02
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            double degrees = radius * 180 / Math.PI;
            Console.WriteLine(degrees);
        }
    }
}
