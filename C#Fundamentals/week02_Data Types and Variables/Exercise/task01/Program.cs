using System;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int fisrtNumber = int.Parse(Console.ReadLine());
            int secoundNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());

            double result = (fisrtNumber + secoundNumber) / thirdNumber * fourthNumber;

            Console.WriteLine(result);
        }
    }
}
