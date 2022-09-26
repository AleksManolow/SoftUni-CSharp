using System;
using System.Collections.Generic;
using System.Linq;

namespace task01_Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            string[] names = Console.ReadLine().Split(' ');

            printNames(names);
        }
    }
}
