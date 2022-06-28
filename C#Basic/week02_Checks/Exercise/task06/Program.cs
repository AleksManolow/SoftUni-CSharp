using System;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSec = double.Parse(Console.ReadLine());
            double distanceM = double.Parse(Console.ReadLine());
            double secOnOneM = double.Parse(Console.ReadLine());

            double a = distanceM * secOnOneM;
            double b = Math.Floor((distanceM / 15)) * 12.50;
            double time = a + b;

            if(recordSec <= time)
            {
                Console.WriteLine($"No, he failed! He was {Math.Abs(time - recordSec):F2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {time:F2} seconds.");
            }
        }
    }
}
