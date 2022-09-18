using System;
using System.Linq;

namespace task01_Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                int[] tempMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = tempMatrix[j];
                    sum += matrix[i, j];
                }
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            

        }
    }
}
