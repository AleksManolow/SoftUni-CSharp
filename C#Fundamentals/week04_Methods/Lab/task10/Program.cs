using System;

namespace task10
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(getSumOddDigits(Math.Abs(number)) * getSumEvenDigits(Math.Abs(number)));
        }
        static int getSumOddDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                if ((number % 10) % 2 == 1)
                {
                    sum += (number % 10);
                }
                number /= 10;
            }
            return sum;
        }
        static int getSumEvenDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                if ((number % 10) % 2 == 0)
                {
                    sum += (number % 10);
                }
                number /= 10;
            }
            return sum;
        }
    }
}
