using System;

namespace task08
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int timeEp = int.Parse(Console.ReadLine());
            int timeRest = int.Parse(Console.ReadLine());

            double sum = timeRest * 0.125 + timeRest * 0.25;
            double a = timeEp - (timeRest - sum);
            if (timeRest - sum >= timeEp)
            {
                Console.WriteLine($" You have enough time to watch {name} and left with {Math.Ceiling(Math.Abs(a))} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {name}, you need {Math.Ceiling(a)} more minutes.");
            }
        }
    }
}
