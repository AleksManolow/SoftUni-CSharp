using System;

namespace task08
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPackagesD = int.Parse(Console.ReadLine());
            int numberOfPackagesC = int.Parse(Console.ReadLine());
            double finalAmount = numberOfPackagesD * 2.50 + numberOfPackagesC * 4;
            Console.WriteLine($"{finalAmount} lv. ");
        }
    }
}
