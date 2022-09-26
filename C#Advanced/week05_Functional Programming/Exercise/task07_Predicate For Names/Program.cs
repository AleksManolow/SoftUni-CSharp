using System;
using System.Linq;

namespace task07_Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ');
            Func<string, bool> lessOrEqua = (string x) => x.Length <= n;
            Console.WriteLine(string.Join(Environment.NewLine, names.Where(x => lessOrEqua(x))));
        }
    }
}
