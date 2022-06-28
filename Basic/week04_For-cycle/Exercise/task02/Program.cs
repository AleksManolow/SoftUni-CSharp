using System;

namespace task08
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int maxNum = int.MinValue;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());

                if (currNum > maxNum)
                {
                    maxNum = currNum;
                }
                sum += currNum;
            }
            int curr = sum - maxNum;
            if (curr == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {maxNum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(maxNum - curr)}");
            }
        }
    }
}