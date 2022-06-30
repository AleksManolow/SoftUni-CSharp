using System;

namespace task11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            for (int i = 0; i < n; i++)
            {
                double priceCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());
                Console.WriteLine($"The price for the coffee is: ${((days * capsulesCount) * priceCapsule):F2}");
                totalPrice += ((days * capsulesCount) * priceCapsule);
            }
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
