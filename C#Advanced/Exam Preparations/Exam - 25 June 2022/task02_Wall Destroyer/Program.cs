using System;

namespace task02_Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            
            int cordI = 0;
            int cordJ = 0;
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = row[j];
                    if (matrix[i, j] == 'V')
                    {
                        cordI = i;
                        cordJ = j;
                    }
                }
            }

            int countHoles = 1;
            int countSteelRod = 0;

            bool isGotElectrocuted = false;
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
                    case "left":
                        newCordJ--;
                        break;
                    case "right":
                        newCordJ++;
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
                    continue;
                }

                if (matrix[newCordI, newCordJ] == 'R')
                {
                    countSteelRod++;
                    Console.WriteLine("Vanko hit a rod!");
                    continue;
                }
                else if (matrix[newCordI, newCordJ] == 'C')
                {
                    isGotElectrocuted = true;
                    matrix[cordI, cordJ] = '*';
                    matrix[newCordI, newCordJ] = 'E';
                    countHoles++;
                    break;
                }
                else if (matrix[newCordI, newCordJ] == '*')
                {
                    matrix[cordI, cordJ] = '*';
                    cordI = newCordI;
                    cordJ = newCordJ;
                    matrix[newCordI, newCordJ] = 'V';
                    Console.WriteLine($"The wall is already destroyed at position [{newCordI}, {newCordJ}]!");
                    continue;
                }

                matrix[cordI, cordJ] = '*';
                countHoles++;
                cordI = newCordI;
                cordJ = newCordJ;
                matrix[newCordI, newCordJ] = 'V';

            }


            if (isGotElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {countHoles} hole(s) and he hit only {countSteelRod} rod(s).");
            }

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
