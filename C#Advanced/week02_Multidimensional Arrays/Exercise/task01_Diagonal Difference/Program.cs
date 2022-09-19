using System;
using System.Linq;

namespace task01_Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            int sumFDiagonal = 0;
            int sumSDiagonal = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        sumFDiagonal += matrix[i, j];
                    }
                    if (i + j == n - 1)
                    {
                        sumSDiagonal += matrix[i, j];
                    }
                }
            }
            Console.WriteLine(Math.Abs(sumFDiagonal - sumSDiagonal));
        }
    }
}
