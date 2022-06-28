using System;

namespace task08
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTurnirs = int.Parse(Console.ReadLine());
            int numberOfRang = int.Parse(Console.ReadLine());
            double wCount = 0;
            double count = 0;
            for (int i = 0; i < numberOfTurnirs; i++)
            {
                string stageOfTournament = Console.ReadLine();
                if (stageOfTournament == "W")
                {
                    count += 2000;
                    wCount++;
                }
                else if (stageOfTournament == "F")
                {
                    count += 1200;
                }
                else if (stageOfTournament == "SF")
                {
                    count += 720;
                }
            }
            Console.WriteLine($"Final points: {count + numberOfRang}");
            Console.WriteLine($"Average points: {Math.Floor(count / numberOfTurnirs)}");
            Console.WriteLine($"{Math.Round((wCount / numberOfTurnirs) * 100, 2):F2}%");
        }
    }
}
