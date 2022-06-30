using System;

namespace task02
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            receives(number);
        }
        static void receives(double number)
        {
            if (number < 3)
            {
                Console.WriteLine("Fail");
            }
            else if (number < 3.5)
            {
                Console.WriteLine("Poor");
            }
            else if (number < 4.5)
            {
                Console.WriteLine("Good");
            }
            else if (number < 5.5)
            {
                Console.WriteLine("Very good");
            }
            else 
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}
