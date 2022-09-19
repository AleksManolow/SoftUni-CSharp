using System;
using System.Linq;

namespace task04_Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsSize = matrixSize[0];
            int colsSize = matrixSize[1];
            string[,] matrix = new string[rowsSize, colsSize];

            for (int row = 0; row < rowsSize; row++)
            {
                string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < colsSize; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            string[] input = Console.ReadLine().Split(' ');
            while (input[0] != "END")
            {
                if (input[0] == "swap" && input.Length <= 5 &&
                     int.Parse(input[1]) >= 0 && int.Parse(input[2]) >= 0 && int.Parse(input[1]) < rowsSize && int.Parse(input[2]) < colsSize &&
                     int.Parse(input[3]) >= 0 && int.Parse(input[4]) >= 0 && int.Parse(input[3]) < rowsSize && int.Parse(input[4]) < colsSize)
                {
                    int row1 = int.Parse(input[1]);
                    int col1 = int.Parse(input[2]);
                    int row2 = int.Parse(input[3]);
                    int col2 = int.Parse(input[4]);
                    //swap
                    string temp = matrix[row1,col1];
                    matrix[row1,col1] = matrix[row2,col2];
                    matrix[row2,col2] = temp;
                    //print
                    for (int i = 0; i < rowsSize; i++)
                    {
                        for (int j = 0; j < colsSize; j++)
                        {
                            Console.Write($"{matrix[i,j]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                    Console.WriteLine("Invalid input!");


                input = Console.ReadLine().Split(' ');
            }

        }
    }
}
