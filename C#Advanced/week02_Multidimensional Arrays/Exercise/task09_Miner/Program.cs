using System;
using System.Linq;
using System.Threading;

namespace task09_Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine().Split(' ');

            int playerRow = 0;
            int playerCol = 0;
            char[, ] matrix = new char[size, size];
            for (int i = 0; i < size; i++)
            {
                char[] row = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();    
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = row[j];
                    if (matrix[i, j] == 's')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
            bool isEndOfGame = false;
            int coals = numberOfCoals(matrix);
            foreach (string command in commands)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                bool correctMove = true;
                switch (command)
                {
                    case "up":
                        newPlayerRow--;
                        MovePlayer(newPlayerRow, newPlayerCol, ref matrix, ref correctMove, ref coals, ref isEndOfGame);
                        break;
                    case "down":
                        newPlayerRow++;
                        MovePlayer(newPlayerRow, newPlayerCol, ref matrix, ref correctMove, ref coals, ref isEndOfGame);
                        break;
                    case "right":
                        newPlayerCol++;
                        MovePlayer(newPlayerRow, newPlayerCol, ref matrix, ref correctMove, ref coals, ref isEndOfGame);
                        break;
                    case "left":
                        newPlayerCol--;
                        MovePlayer(newPlayerRow, newPlayerCol, ref matrix, ref correctMove, ref coals, ref isEndOfGame);
                        break;
                }
                if (correctMove)
                {
                    matrix[playerRow, playerCol] = '*';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }

                if (isEndOfGame)
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    break;
                }
                else if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                    break;
                }
            }
            if (!isEndOfGame && coals != 0)
            {
                Console.WriteLine($"{coals} coals left. ({playerRow}, {playerCol})");
            }

        }
        static void MovePlayer(int row, int col,ref char[, ] matrix ,ref bool correctMove, ref int coals, ref bool isEndofGame)
        {
            if (IsCorrectMove(row, col, matrix))
            {
                if (matrix[row, col] == 'c')
                {
                    coals--;
                }
                else if (matrix[row, col] == 'e')
                {
                    isEndofGame = true;
                }
                matrix[row, col] = 's';
            }
            else
            {
                correctMove = false;
            }
        }
        static bool IsCorrectMove(int row, int col, char[,] matrix)
        {
            return row >= 0 &&
                 row < matrix.GetLength(0) &&
                 col >= 0 &&
                 col < matrix.GetLength(1);
        }
        static int numberOfCoals(char[,] matrix)
        {
            int countCoals = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 'c')
                    {
                        countCoals++;
                    }
                }
            }
            return countCoals;
        }
    }
}
