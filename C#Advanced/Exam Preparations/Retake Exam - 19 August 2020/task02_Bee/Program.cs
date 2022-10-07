using System;

namespace task02_Bee
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
                string temp = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    map[i, j] = temp[j];
                    if (temp[j] == 'B')
                    {
                        cordI = i;
                        cordJ = j;
                    }
                }
            }

            int countFlower = 0;
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
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                if (command == "End")
                {
                    break;
                }
                if (map[cordI, cordJ] == 'f')
                {
                    countFlower++;
                }
                else if (map[cordI, cordJ] == 'O')
                {
                    map[cordI, cordJ] = '.';
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

                    if (map[cordI, cordJ] == 'f')
                        countFlower++;

                }

                map[lastCordI, lastCordJ] = '.';
                map[cordI, cordJ] = 'B';
            }
            if (countFlower < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - countFlower} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {countFlower} flowers!");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
