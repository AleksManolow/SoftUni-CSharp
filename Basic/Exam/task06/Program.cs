using System;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            int K = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            int count = 0;

            for (int k = K; k <= 8 && count != 6; k++)
            {
                for (int l = 9; l >= L && count != 6; l--)
                {
                    for (int m = M; m <= 8 && count != 6; m++)
                    {
                        for (int n = 9; n >= N && count != 6; n--)
                        {

                            if (k % 2 == 0 && l % 2 != 0 && m % 2 == 0 && n % 2 != 0)
                            {
                                if (k == m && l == n)
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                }
                                else
                                {
                                    Console.WriteLine($"{k}{l} - {m}{n}");
                                    count++;
                                }
                                
                            }
                        }
                    }
                }
            }

        }
    }
}
