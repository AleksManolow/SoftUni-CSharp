using System;
using System.Linq;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            
            for (int i = 0; i < numbers.Length; i++)
            {
                int rightSum = 0;
                for (int j = 0; j < i; j++)
                {
                    rightSum += numbers[j];
                }
                int leftSum = 0;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    leftSum += numbers[j];
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
