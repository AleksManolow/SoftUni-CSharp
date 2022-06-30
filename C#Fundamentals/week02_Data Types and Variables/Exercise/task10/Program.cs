using System;

namespace task10
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int executionFactor = int.Parse(Console.ReadLine());
            int startingPower = power;
            int countOfPoked = 0;
            while (power >= distance )
            {
                power -= distance;
                countOfPoked++;
                if (startingPower * 0.5 == power && executionFactor > 0)
                {
                    power /= executionFactor;
                }
            }
            Console.WriteLine(power);
            Console.WriteLine(countOfPoked);
        }
    }
}
