using System;

namespace task11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int t = int.Parse(Console.ReadLine());

            int i = t;
            do
            {
                Console.WriteLine($"{n} X {i} = {i * n}");
                i++;
            } while (i <= 10);
        }
    }
}
