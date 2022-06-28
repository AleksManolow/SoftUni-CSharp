using System;

namespace task08
{
    class Program
    {
        static void Main(string[] args)
        {
            int feeForYear = int.Parse(Console.ReadLine());
            double sneakers = feeForYear - (feeForYear * 0.4);
            double clothes = sneakers - (sneakers * 0.2);
            double boll = 0.25 * clothes;
            double accessories = 0.2 * boll;
            double total = feeForYear + sneakers + clothes + boll + accessories;
            Console.WriteLine(total);

        }
    }
}
