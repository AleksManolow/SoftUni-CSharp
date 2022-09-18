using System;
using System.Linq;

namespace task05_Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] tempMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = tempMatrix[j]; 
                }
            }
            int maxSum = 0;
            int iEl = 0;
            int jEl = 0;
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    if (matrix[i,j] + matrix[i,j +1] + matrix[i +1,j] + matrix[i + 1, j +1] > maxSum)
                    {
                        maxSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                        iEl = i;
                        jEl = j;                
                    }
                }
            }
            for (int i = iEl; i <= iEl + 1; i++)
            {
                for (int j = jEl; j <= jEl + 1; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);

        }
    }
}
