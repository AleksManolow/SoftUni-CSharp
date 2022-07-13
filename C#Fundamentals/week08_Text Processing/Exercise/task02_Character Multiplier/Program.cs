using System;

namespace task02_Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string str1 = input[0];
            string str2 = input[1];

            int result = 0;
            for (int i = 0; i < Math.Min(str1.Length, str2.Length); i++)
            {
                result += (int)str1[i] * (int)str2[i];
            }
            if (str1.Length > str2.Length)
            {
                for (int i = str2.Length; i < str1.Length; i++)
                {
                    result += (int)str1[i];
                }
            }
            else
            {
                for (int i = str1.Length; i < str2.Length; i++)
                {
                    result += (int)str2[i];
                }
            }
            Console.WriteLine(result);
        }
    }
}
