using System;

namespace task04
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            int count = 0;
            string pass = "";
            for (int i = username.Length - 1; i >= 0; i--)
            {
                pass += username[i];
            }
            Console.WriteLine(pass);

        }
    }
}