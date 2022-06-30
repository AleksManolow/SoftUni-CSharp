using System;
using System.Linq;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fisrtArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secoundArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = 0;
            for (int i = 0; i < fisrtArr.Length; i++)
            {
                if (fisrtArr[i] == secoundArr[i])
                {
                    sum += fisrtArr[i];
                }
                else
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    break;
                }

                if (i == fisrtArr.Length - 1)
                {
                    Console.WriteLine($"Arrays are identical. Sum: {sum}");
                }

            }
        }
    }
}
