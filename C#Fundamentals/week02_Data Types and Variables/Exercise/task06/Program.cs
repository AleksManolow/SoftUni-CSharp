using System;

namespace task06
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Console.Write((char)('a' + i));
                        Console.Write((char)('a' + j));
                        Console.Write((char)('a' + k));
                        Console.WriteLine();

                    }
                }
            }
        }
    }
}
