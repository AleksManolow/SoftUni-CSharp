using System;

namespace task03_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordKey = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.Contains(wordKey))
            {
                text = text.Remove(text.IndexOf(wordKey), wordKey.Length);
            }
            Console.WriteLine(text);
        }
    }
}
