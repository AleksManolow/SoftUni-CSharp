using System;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            char startChar = char.Parse(Console.ReadLine());
            char endChar = char.Parse(Console.ReadLine());

            PrintCharactersBetween((char)Math.Min((int) startChar, (int)endChar), (char)Math.Max((int)startChar, (int)endChar));
        }
        static void PrintCharactersBetween(char startChar, char endChar)
        {
            for (int i = (int)startChar + 1; i < (int)endChar ; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
