using System;
using System.Linq;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int count = 0;
            int startIndex = 0;
            int maxCount = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    count++;
                    if (maxCount < count)
                    {
                        startIndex = i - count + 1;
                        maxCount = count;
                    }
                }
                else
                {
                    count = 0;
                }

            }
            for (int i = startIndex; i <= startIndex + maxCount; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
    }
}
