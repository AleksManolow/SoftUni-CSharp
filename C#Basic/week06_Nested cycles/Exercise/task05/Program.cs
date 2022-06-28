using System;

namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1111; i < 9999; i++)
            {
                int count = 0;
                int temp = i;
                while(temp != 0)
                {
                    if (temp % 10 != 0 && n % (temp % 10) == 0)
                    {
                        count++;
                    }
                    temp /= 10;
                }
                if(count == 4)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
