using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace task05_Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            string sanakeInput = Console.ReadLine();
            Queue<char> snake = new Queue<char>(sanakeInput);
            char[, ] matrix = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    snake.Enqueue(snake.Peek());
                    matrix[i, j] = snake.Dequeue();
                }
                if (++i >= rows)
                {
                    break;
                }
                for (int j = cols - 1; j >= 0; j--)
                {
                    snake.Enqueue(snake.Peek());
                    matrix[i, j] = snake.Dequeue();
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
