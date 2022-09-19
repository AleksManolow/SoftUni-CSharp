using System;
using System.Linq;

namespace task06_Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int[][] jaggedMatrix = new int[row][];  
            for (int i = 0; i < row; i++)
            {
                jaggedMatrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            for (int i = 0; i < row - 1; i++)
            {
                if (jaggedMatrix[i].Length == jaggedMatrix[i + 1].Length)
                {
                    for (int j = 0; j < jaggedMatrix[i].Length; j++)
                    {
                        jaggedMatrix[i][j] *= 2;
                        jaggedMatrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedMatrix[i].Length; j++)
                    {
                        jaggedMatrix[i][j] /= 2;
                    }
                    for (int j = 0; j < jaggedMatrix[i + 1].Length; j++)
                    {
                        jaggedMatrix[i + 1][j] /= 2;
                    }
                }
            }
            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                if (command[0] == "Add" && int.Parse(command[1]) >= 0 && int.Parse(command[1]) < row &&
                    int.Parse(command[2]) >= 0 && int.Parse(command[2]) < jaggedMatrix[int.Parse(command[1])].Length)
                {
                    jaggedMatrix[int.Parse(command[1])][int.Parse(command[2])] += int.Parse(command[3]); 
                }
                else if (command[0] == "Subtract" && int.Parse(command[1]) >= 0 && int.Parse(command[1]) < row &&
                    int.Parse(command[2]) >= 0 && int.Parse(command[2]) < jaggedMatrix[int.Parse(command[1])].Length)
                {
                    jaggedMatrix[int.Parse(command[1])][int.Parse(command[2])] -= int.Parse(command[3]);
                }

                command = Console.ReadLine().Split();
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < jaggedMatrix[i].Length; j++)
                {
                    Console.Write($"{jaggedMatrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
