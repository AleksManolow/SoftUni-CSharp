using System;


namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string sentence = "";
            int index = 0;

            char ch = '\0';

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();

                int len = str.Length;
                int num = int.Parse(str);
                if (num == 0)
                {
                    ch = ' ';
                }
                else
                {
                    int digit = num % 10;

                    int offset = (digit - 2) * 3;

                    if (digit == 8 || digit == 9)
                    {
                        offset++;
                    }

                    index = offset + len - 1;
                    ch = (char)(97 + index);
                }
                sentence += ch;
            }
            Console.WriteLine(sentence);
        }


    }
}