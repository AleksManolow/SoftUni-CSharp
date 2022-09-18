using System;
using System.Linq;

namespace task04_Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] row = Console.ReadLine().ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            bool doesOccur = false;    
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        doesOccur = true;
                        break;
                    }
                }
                if (doesOccur)
                {
                    break;
                }
            }
            if (!doesOccur)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
