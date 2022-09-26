using System;
using System.Linq;

namespace task11_TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum =int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ');

            Func<string, int, bool> isLargerOrRqualToAscii = (name, sum)
                => name.Sum(x => x) >= sum;
            Func<string[], Func<string, int, bool>, string> getName = (name, func)
                => names.Where(x => func(x, sum)).FirstOrDefault();
            Console.WriteLine(getName(names, isLargerOrRqualToAscii));
                
        }
    }
}
