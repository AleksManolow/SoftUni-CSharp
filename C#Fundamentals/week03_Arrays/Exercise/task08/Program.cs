using System;
using System.Linq;

namespace task08
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[i] + elements[j] == number)
                    {
                        Console.WriteLine($"{elements[i]} {elements[j]}");
                    }
                }
            }
        }
    }
}
