using System;
using System.Linq;

namespace task06_Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).Reverse().ToArray();
            int n = int.Parse(Console.ReadLine());
            Func<int, bool> divisible = x => x % n != 0;
            Console.WriteLine(string.Join(' ', numbers.Where(x => divisible(x)))); 


        }
    }
}
