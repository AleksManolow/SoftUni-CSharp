using System;
using System.Linq;

namespace task06_Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowN = int.Parse(Console.ReadLine());
            int[][] jagggedArr = new int[rowN][];
            for (int i = 0; i < rowN; i++)
            {
                jagggedArr[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }
            string[] command = Console.ReadLine().Split(' ');
            while (command[0] != "END")
            {
                int cordI = int.Parse(command[1]);
                int cordJ = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if (command[0] == "Add")
                {
                    if (jagggedArr.Length > cordI && jagggedArr[cordI].Length > cordJ && cordI >= 0 && cordJ >= 0)
                    {
                        jagggedArr[cordI][cordJ] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (command[0] == "Subtract")
                {
                    if (jagggedArr.Length > cordI && jagggedArr[cordI].Length > cordJ && cordI >=0 && cordJ >=0)
                    {
                        jagggedArr[cordI][cordJ] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }   

                command = Console.ReadLine().Split(' ');
            }
            for (int i = 0; i < jagggedArr.Length; i++)
            {
                for (int j = 0; j < jagggedArr[i].Length; j++)
                {
                    Console.Write($"{jagggedArr[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
