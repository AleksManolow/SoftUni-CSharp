using System;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            const int CAPACITY = 255;
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int p = int.Parse(Console.ReadLine());
                if (sum + p > CAPACITY)
                {
                    Console.WriteLine("Insufficient capacity!");
                    
                }
                else
                {
                    sum += p;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
