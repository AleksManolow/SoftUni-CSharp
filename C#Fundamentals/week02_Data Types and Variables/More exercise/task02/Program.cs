using System;

namespace task02
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input  = Console.ReadLine();

                int a = 0;
                int b = 0;
                string temp = "";
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == ' ')
                    {
                        a = int.Parse(temp);
                        temp = "";
                    }
                    else
                    {
                        temp += input[j];

                    }
                }
                b = int.Parse(temp);
                
                if (a > b)
                {
                    int sum = 0;
                    while (a != 0)
                    {
                        sum += (a % 10);
                        a /= 10;
                    }
                    Console.WriteLine(sum);
                }
                else
                {
                    int sum = 0;
                    while (b != 0)
                    {
                        sum += (b % 10);
                        b /= 10;
                    }
                    Console.WriteLine(sum);
                }
            }
        }
    }
}
