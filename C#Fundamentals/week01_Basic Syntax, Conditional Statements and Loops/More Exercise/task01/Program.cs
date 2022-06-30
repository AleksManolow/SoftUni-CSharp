using System;

namespace task01
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            if (a <= b && b <= c)
            {
                Console.WriteLine(c);
                Console.WriteLine(b);
                Console.WriteLine(a);
            }
            else if (a <= b && c <= b)
            {
                Console.WriteLine(b);
                Console.WriteLine(c);
                Console.WriteLine(a);
            }
            else if (b <= a && a <= c)
            {
                Console.WriteLine(c);
                Console.WriteLine(a);
                Console.WriteLine(b);
            }
            else if (b <= c && c <= a)
            {
                Console.WriteLine(a);
                Console.WriteLine(c);
                Console.WriteLine(b);
            }
            else if (c <= a && a <= b)
            {
                Console.WriteLine(b);
                Console.WriteLine(a);
                Console.WriteLine(c);
            }
            else if (c <= b && b <= a)
            {
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine(c);
            }

        }
    }
}
