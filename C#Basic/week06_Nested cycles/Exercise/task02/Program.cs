using System;

namespace task02
{
    class Program
    {
        static void Main(string[] args)
        {
            int fisrtNUm = int.Parse(Console.ReadLine());
            int secoundNum = int.Parse(Console.ReadLine());

            for (int i = fisrtNUm; i <= secoundNum; i++)
            {
                string curr = i.ToString();
                int evenSum = 0;
                int oldSum = 0;
                for (int j = 0; j < curr.Length ; j++)
                {
                    int currDigit = int.Parse(curr[j].ToString());
                    if (j % 2 == 0)
                    {
                        evenSum += currDigit;
                    }
                    else
                    {
                        oldSum += currDigit;
                    }
                }
                if (oldSum == evenSum)
                {
                    Console.Write($"{i} ");
                }

            }
        }
    }
}
