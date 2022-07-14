using System;
using System.Text;

namespace task07_String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            int power = 0;
            StringBuilder outputText = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '>')
                {
                    power += ((int)text[i + 1] - 48);
                    outputText.Append(text[i]);
                }
                else
                {
                    if (power > 0)
                    {
                        power--;
                    }
                    else
                    {
                        outputText.Append(text[i])  ;
                    }
                }
            }

            Console.WriteLine(outputText);
        }
    }
}
