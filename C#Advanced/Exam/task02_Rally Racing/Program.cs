using System;
using System.Linq;

namespace task02_Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string racingNumber = Console.ReadLine();

            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            int kilometers = 0;

            bool isWinner = false;

            int cordI = 0;
            int cordJ = 0;
            matrix[cordI, cordJ] = 'C';

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
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


                if (matrix[newCordI, newCordJ] == 'T')
                {
                    matrix[cordI, cordJ] = '.';
                    matrix[newCordI, newCordJ] = '.';
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (matrix[i, j] == 'T')
                            {
                                newCordI = i;
                                newCordJ = j;
                            }
                        }
                    }
                    kilometers += 30;
                    matrix[newCordI, newCordJ] = 'C';
                }
                else if (matrix[newCordI, newCordJ] == 'F')
                {
                    matrix[cordI, cordJ] = '.';
                    matrix[newCordI, newCordJ] = 'C';
                    isWinner = true;
                    kilometers += 10;
                    break;
                }
                else if(matrix[newCordI, newCordJ] == '.')
                {
                    matrix[cordI, cordJ] = '.';
                    matrix[newCordI, newCordJ] = 'C';
                    kilometers += 10;
                }

                cordI = newCordI;
                cordJ = newCordJ;
            }


            if (isWinner)
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }
            Console.WriteLine($"Distance covered {kilometers} km.");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
