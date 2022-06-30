using System;

namespace task09
{
    class Program
    {
        static void Main(string[] args)
        {
            const int CONSUME_BY_WORKERS = 26;
            const int MIN = 100;
            const int DAILY = 10;

            int countOfSpices = int.Parse(Console.ReadLine());
            int totalConsumed = 0;
            int daysCounter = 0;

            while (countOfSpices >= MIN)
            {
                totalConsumed += countOfSpices - CONSUME_BY_WORKERS;
                countOfSpices -= DAILY;
                daysCounter++;
                if (countOfSpices < MIN)
                {
                    totalConsumed -= CONSUME_BY_WORKERS;
                }
            }
            Console.WriteLine(daysCounter);
            Console.WriteLine(totalConsumed);
        }
    }
}
