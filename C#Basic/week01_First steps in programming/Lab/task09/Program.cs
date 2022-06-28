using System;

namespace task09
{
    class Program
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());

            double price = area * 7.61;
            double discount = 0.18 * price;
            double endPrice = price - discount;
            Console.WriteLine($"The final price is: {endPrice}");
            Console.WriteLine($"The discount is: {discount}");
        }
    }
}
