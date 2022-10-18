using System;

namespace task02_Help_A_Mole
{
    public class Program
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
                    if (matrix[i, j] == 'M')
                    {
                        cordI = i;
                        cordJ = j;
                    }
                }
            }

            bool isCollectedPoints = false;
            int points = 0;
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
                if (newCordI < 0 || newCordI >= n || newCordJ < 0 || newCordJ >= n)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    continue;
                }

                if (char.IsDigit(matrix[newCordI, newCordJ]))
                {
                    points += (int)(matrix[newCordI, newCordJ]) - '0';
                }
                else if (matrix[newCordI, newCordJ] == 'S')
                {
                    matrix[newCordI, newCordJ] = '-';
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (matrix[i, j] == 'S')
                            {
                                newCordI = i;
                                newCordJ = j;
                            }
                        }
                    }
                    points -= 3;
                }

                
                matrix[cordI, cordJ] = '-'; 
                cordI = newCordI;
                cordJ = newCordJ;
                matrix[cordI, cordJ] = 'M';
                if (points >= 25)
                {
                    isCollectedPoints = true;
                    break;
                }
            }
            if (isCollectedPoints)
                Console.WriteLine("Yay! The Mole survived another game!");
            else
                Console.WriteLine("Too bad! The Mole lost this battle!");

            if (points >= 25)
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            else
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            
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
