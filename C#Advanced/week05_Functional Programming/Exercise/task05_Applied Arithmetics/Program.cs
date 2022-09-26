using System;
using System.ComponentModel;
using System.Linq;

namespace task05_Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Func<int, int> funcAdd = (int x) => x + 1;
            Func<int, int> funcMultiply = (int x) => x * 2;
            Func<int, int> funcSubtract = (int x) => x - 1;
            

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(x => funcAdd(x)).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => funcMultiply(x)).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => funcSubtract(x)).ToArray();
                        break ;
                    case "print":
                        Console.WriteLine(string.Join(' ', numbers));
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
