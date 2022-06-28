using System;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            double sumS = 0;
            double sumA = 0;
            if (month == "May" || month == "October")
            {
                sumA = number * 65;
                sumS = number * 50;
                if (number > 14)
                {
                    sumS = sumS - (sumS * 0.3);
                }
                else if (number > 7)
                {
                    sumS = sumS - (sumS * 0.05);
                }
            }
            else if (month == "June" || month == "September")
            {
                sumA = number * 68.70;
                sumS = number * 75.20;
                if (number > 14)
                {
                    sumS = sumS - (sumS * 0.2);
                }
            }
            else
            {
                sumA = number * 77;
                sumS = number * 76;
            }
            if (number > 14)
            {
                sumA = sumA - (sumA * 0.1);
            }
            Console.WriteLine($"Apartment: {sumA:F2} lv.");
            Console.WriteLine($"Studio: {sumS:F2} lv.");
        }
    }
}
