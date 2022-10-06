using System;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace task02_Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] map = new char[n,n];

            int cordI = 0;
            int cordJ = 0;
            for (int i = 0; i < n; i++)
            {
                string temp = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    map[i, j] = temp[j];
                    if (temp[j] == 'S')
                    {
                        cordI = i;
                        cordJ = j;
                    }
                }
            }

            int countFood = 0;
            while (true)
            {
                string command = Console.ReadLine();

                int lastCordI = cordI;
                int lastCordJ = cordJ;
                if (command == "left")
                {
                    cordJ--;
                }
                else if (command == "right")
                {
                    cordJ++;
                }
                else if (command == "down")
                {
                    cordI++;
                }
                else if (command == "up")
                {
                    cordI--;
                }

                if (cordI < 0 || cordI >= n || cordJ < 0 || cordJ >= n)
                {
                    map[lastCordI, lastCordJ] = '.';
                    Console.WriteLine("Game over!");
                    break;
                }

                if (map[cordI, cordJ] == '*')
                {
                    countFood++;
                }
                else if (map[cordI, cordJ] == 'B')
                {
                    map[cordI, cordJ] = '.';
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (map[i, j] == 'B')
                            {
                                cordI = i;
                                cordJ = j;
                                break;
                            }
                        }
                    }
                }
                map[lastCordI, lastCordJ] = '.';
                map[cordI, cordJ] = 'S';

                if (countFood >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }
            }
            Console.WriteLine($"Food eaten: {countFood}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(map[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
