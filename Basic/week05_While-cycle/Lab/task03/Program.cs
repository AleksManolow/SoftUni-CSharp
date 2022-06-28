using System;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            while (number > sum )
            {
                int curr = int.Parse(Console.ReadLine());
                sum += curr;
            }
            Console.WriteLine(sum);
        }
    }
}
