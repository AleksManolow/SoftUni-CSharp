using System;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeoples = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            double numberMark = 0;

            int count = 0;
            double allSum = 0;
            while(name != "Finish")
            {
                count++;
                double sum = 0;
                for (int i = 0; i < numberOfPeoples; i++)
                {
                    numberMark = double.Parse(Console.ReadLine());
                    sum += numberMark;
                }
                allSum += sum / numberOfPeoples;
                Console.WriteLine($"{name} - {sum / numberOfPeoples:F2}.");
                name = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {allSum / count:F2}.");
        }
    }
}
