using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace task02_Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputRowAndCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = inputRowAndCol[0];
            int col = inputRowAndCol[1];

            int[,] garden = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    garden[i, j] = 0;
                }
            }
            while (true)
            {
                string input = Console.ReadLine(); 
                if ("Bloom Bloom Plow" == input)
                { 
                    break;
                }

                int cordI = int.Parse(input.Split(' ')[0]);
                int cordJ = int.Parse(input.Split(' ')[1]);
                if (cordI < 0 || cordI >= row || cordJ < 0 || cordJ >= col)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    Bloom(ref garden, cordI, cordJ);
                }
                
            }

            printGarden(garden);
        }
        static void Bloom(ref int[,] garden, int cordI, int cordJ)
        {
            for (int i = 0; i < garden.GetLength(1); i++)
            {
                garden[cordI, i]++;
            }
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                if (i != cordI)
                {
                    garden[i, cordJ]++;
                }
                
            }
        }
        static void printGarden(int[,] garden)
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
