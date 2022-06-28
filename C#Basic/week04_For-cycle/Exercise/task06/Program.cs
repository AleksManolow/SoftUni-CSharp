using System;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double pointsToAcademy = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n && pointsToAcademy < 1250.5; i++)
            {
                string nameEvaluation = Console.ReadLine();
                double pointToEvaluation = double.Parse(Console.ReadLine());

                pointsToAcademy += (nameEvaluation.Length * pointToEvaluation) / 2;
            }

            if(pointsToAcademy < 1250.5)
            {
                Console.WriteLine($"Sorry, {name} you need {1250.5 - pointsToAcademy :F1} more!");
            }
            else
            {
                Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {pointsToAcademy :F1}!");
            }
        }
    }
}
