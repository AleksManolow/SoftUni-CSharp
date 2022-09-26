using System;

namespace task02_Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = x => Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ",x));

            string[] names = Console.ReadLine().Split(' ');

            printNames(names);
        }
    }
}
