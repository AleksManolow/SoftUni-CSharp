using System;

namespace task07
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(rereatString(input, n));
        }
        static string rereatString(string s, int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += s;
            }
            return result;
        }
    }
}
