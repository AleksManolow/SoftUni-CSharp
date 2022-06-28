using System;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            if(number >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
