using System;
using System.Linq;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sumEvenEl = 0;
            int sumOddEl = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    sumEvenEl += arr[i];
                }
                else
                {
                    sumOddEl += arr[i];
                }
            }
            Console.WriteLine(sumEvenEl - sumOddEl);
        }
    }
}
