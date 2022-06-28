using System;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());

            int megicNum = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = s; i <= f; i++)
            {
                for (int j = s; j <= f; j++)
                {
                    count++;
                    if (i + j == megicNum)
                    {
                        Console.WriteLine($"Combination N:{count} ({i} + {j} = {megicNum})");
                        return;
                    }
                }

            }

            Console.WriteLine($"{count} combinations - neither equals {megicNum}");
        }
    }
}
