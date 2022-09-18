using System;
using System.Linq;

namespace task02_Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();  
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sumCol = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sumCol += matrix[j, i];
                }
                Console.WriteLine(sumCol);
            }
        }
    }
}
