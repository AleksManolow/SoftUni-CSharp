using System;

namespace task05_Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string digits = "";
            string letter = "";
            string others = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    digits += text[i];
                }
                else if (char.IsLetter(text[i]))
                {
                    letter += text[i];
                }
                else
                {
                    others += text[i];
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letter);
            Console.WriteLine(others);
        }
    }
}
