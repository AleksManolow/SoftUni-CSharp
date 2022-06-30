using System;

namespace task02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vehicles = Console.ReadLine().Split(">>");
            double sumTotalPay = 0;
            for (int i = 0; i < vehicles.Length; i++)
            {
                string[] vehicle = vehicles[i].Split();
                string type = vehicle[0];
                int years = int.Parse(vehicle[1]);
                int km = int.Parse(vehicle[2]);
                

                double totalPay = 0;
                if (type == "family")
                {
                    totalPay = km / 3000 * 12 + (50 - years * 5);
                    Console.WriteLine($"A {type} car will pay {totalPay:F2} euros in taxes.");
                }
                else if (type == "heavyDuty")
                {
                    totalPay = km / 9000 * 14 + (80 - years * 8);
                    Console.WriteLine($"A {type} car will pay {totalPay:F2} euros in taxes.");
                }
                else if (type == "sports")
                {
                    totalPay = km / 2000 * 18 + (100 - years * 9);
                    Console.WriteLine($"A {type} car will pay {totalPay:F2} euros in taxes.");
                }
                else
                {
                    Console.WriteLine("Invalid car type.");
                }
                sumTotalPay += totalPay;
            }
            Console.WriteLine($"The National Revenue Agency will collect {sumTotalPay:F2} euros in taxes.");
        }
    }
}
