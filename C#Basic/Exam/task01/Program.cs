using System;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroub = int.Parse(Console.ReadLine());
            int numberOfNigth = int.Parse(Console.ReadLine());
            int numberOfKards = int.Parse(Console.ReadLine());
            int numberOfTikets = int.Parse(Console.ReadLine());

            double sum = 0;
            sum += (numberOfNigth * 20);
            sum += (numberOfKards * 1.60);
            sum += (numberOfTikets * 6);

            sum *= numberOfGroub;
            sum += (0.25 * sum);
            Console.WriteLine($"{sum:F2}");

        }
    }
}
