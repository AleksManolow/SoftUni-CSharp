using System;

namespace task02
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            for (int i = size - 1; i >= 0; i--)
            {
                Console.Write($"{arr[i]} ");
            }
        }
    }
}
