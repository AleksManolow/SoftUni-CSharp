using System;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudent = int.Parse(Console.ReadLine());
            double evaluation = 0;

            int cout1 = 0;
            int cout2 = 0;
            int cout3 = 0;
            int cout4 = 0;
            double sumEvaluation = 0;
            for (int i = 0; i < numberOfStudent; i++)
            {
                evaluation = double.Parse(Console.ReadLine());
                sumEvaluation += evaluation;
                if (evaluation < 3)
                {
                    cout1++;
                }
                else if (evaluation < 4)
                {
                    cout2++;
                }
                else if (evaluation < 5)
                {
                    cout3++;
                }
                else 
                {
                    cout4++;
                }
            }
            Console.WriteLine($"Top students: {(double)cout4 * 100 / numberOfStudent:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(double)cout3 * 100 / numberOfStudent:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(double)cout2 * 100 / numberOfStudent:F2}%");
            Console.WriteLine($"Fail: {(double)cout1 * 100 / numberOfStudent:F2}%");
            Console.WriteLine($"Average: {sumEvaluation / numberOfStudent:F2}");
        }
    }
}
