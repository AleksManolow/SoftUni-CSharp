using System;

namespace task03_Count_Uppercase_Words
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Func<string, bool> isUppercase = s => char.IsUpper(s[0]);

            string[] text = Console.ReadLine().Split(' ');
            foreach (var word in text)
            {
                if (isUppercase(word))
                {
                    Console.WriteLine(word);    
                }
            }
        }
    }
}
