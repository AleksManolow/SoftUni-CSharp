using System;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            int chickenInMenu = int.Parse(Console.ReadLine());
            int fishInMenu = int.Parse(Console.ReadLine());
            int vegetarianInMenu = int.Parse(Console.ReadLine());

            double price = chickenInMenu * 10.35 + fishInMenu * 12.40 + vegetarianInMenu * 8.15;
            double orderPrice = price + (price * 0.2) + 2.50;

            Console.WriteLine(orderPrice);

        }
    }
}
