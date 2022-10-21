using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace task02_Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int numberOfBranches = 0;
            int cordI = 0;
            int cordJ = 0;
            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                    if (matrix[i, j] == 'B')
                    {
                        cordI = i;
                        cordJ = j;
                    }

                    if (char.IsLower(matrix[i, j]))
                    {
                        numberOfBranches++;
                    }
                }
            }

            Stack<char> branches = new Stack<char>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                int newCordI = cordI;
                int newCordJ = cordJ;
                switch (command)
                {
                    case "right":
                        newCordJ++;
                        break;
                    case "left":
                        newCordJ--;
                        break;
                    case "down":
                        newCordI++;
                        break;
                    case "up":
                        newCordI--;
                        break;
                }

                if (newCordI < 0 || newCordI >= n || newCordJ < 0 || newCordJ >=n)
                {
                    if (branches.Count != 0)
                    {
                        branches.Pop();
                    }
                    continue;
                }

                if (char.IsLower(matrix[newCordI, newCordJ]))
                {
                    numberOfBranches--;
                    branches.Push(matrix[newCordI, newCordJ]);
                }
                else if (matrix[newCordI, newCordJ] == 'F')
                {
                    matrix[newCordI, newCordJ] = '-';
                    switch (command)
                    {
                        case "up":
                            newCordI = newCordI == 0 ? n - 1 : 0;
                            break;
                        case "down":
                            newCordI = newCordI == n - 1 ? n - 1 : 0;
                            break;
                        case "right":
                            newCordJ = newCordJ == n - 1 ? 0 : n - 1;
                            break;
                        case "left":
                            newCordJ = newCordJ == 0 ? n - 1 : 0;
                            break;
                    }
                    if (char.IsLetter(matrix[newCordI, newCordJ]))
                    {
                        numberOfBranches--;
                        branches.Push(matrix[newCordI, newCordJ]);
                    }
                }

                matrix[cordI, cordJ] = '-';
                cordI = newCordI;
                cordJ = newCordJ;
                matrix[newCordI, newCordJ] = 'B';
                if (numberOfBranches == 0)
                {
                    break;
                }
            }


            if (numberOfBranches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {numberOfBranches} branches left.");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
