using System;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int temp = number;
            int sum = 0;
            while (temp != 0)
            {
                int fact = 1;
                for (int i = 1; i <= temp % 10; i++)
                {
                    fact *= i;
                }
                sum += fact;
                temp /= 10;
            }
            Console.WriteLine(sum == number ? "yes" : "no");
        }
    }
}
