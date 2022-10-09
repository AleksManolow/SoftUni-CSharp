using System;
using System.ComponentModel.Design;

namespace task02_Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] map = new char[n, n];

            int cordI = 0;
            int cordJ = 0;
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    map[i, j] = row[j];
                    if (row[j] == 'S')
                    {
                        cordI = i;
                        cordJ = j;
                    }
                }
            }

            int money = 0;
            while (true)
            {
                string input = Console.ReadLine();
                int newCordI = cordI;
                int newCordJ = cordJ;
                if (input == "up")
                    newCordI--;
                else if (input == "down")
                    newCordI++;
                else if (input == "left")
                    newCordJ--;
                else if (input == "right")
                    newCordJ++;

                if (newCordI < 0 || newCordI >= n || newCordJ < 0 || newCordJ >= n)
                {
                    map[cordI, cordJ] = '-';
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (char.IsDigit(map[newCordI, newCordJ]))
                {
                    money += int.Parse(map[newCordI, newCordJ].ToString());
                }
                else if (map[newCordI, newCordJ] == 'O')
                {
                    map[newCordI, newCordJ] = '-';
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (map[i, j] == 'O')
                            {
                                newCordI = i;
                                newCordJ = j;
                            }
                        }
                    }
                }


                if (money >= 50)
                {
                    map[cordI, cordJ] = '-';
                    map[newCordI, newCordJ] = 'S';
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    break;
                }
                map[cordI, cordJ] = '-';

                cordI = newCordI;
                cordJ = newCordJ;

                map[newCordI, newCordJ] = 'S';
            }
            Console.WriteLine($"Money: {money}");
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
