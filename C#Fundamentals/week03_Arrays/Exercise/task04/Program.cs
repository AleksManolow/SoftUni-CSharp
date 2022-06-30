using System;
using System.Linq;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int temp = elements[0];
                for (int j = 0; j < elements.Length - 1; j++)
                {
                    elements[j] = elements[j + 1];
                }
                elements[elements.Length - 1] = temp;
            }
            Console.WriteLine(string.Join(' ', elements));
        }
    }
}
