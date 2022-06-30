using System;

namespace task02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fisrtStr = Console.ReadLine().Split();
            string[] secoundStr = Console.ReadLine().Split();

            for (int i = 0; i < secoundStr.Length; i++)
            {
                for (int j = 0; j < fisrtStr.Length; j++)
                {
                    if (fisrtStr[j] == secoundStr[i])
                    {
                        Console.Write(secoundStr[i] + " ");
                        continue;
                    }
                }
            }
        }
    }
}
