using System;
using System.Linq;

namespace task01_Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Reveal")
            {
                bool isFlag = true;
                string[] commands = input.Split(":|:");
                if (commands[0] == "InsertSpace")
                {

                    text = text.Substring(0, int.Parse(commands[1])) + ' ' + text.Substring(int.Parse(commands[1]));
                }
                else if (commands[0] == "Reverse")
                {
                    if (text.Contains(commands[1]))
                    {
                        text = text.Remove(text.IndexOf(commands[1]), commands[1].Length);
                        string reverse = "";
                        for (int i = commands[1].Length - 1; i >= 0; i--)
                        {
                            reverse += commands[1][i];
                        }
                        text = text + reverse;
                    }
                    else
                    {
                        Console.WriteLine("error");
                        isFlag = false;
                    }

                }
                else if (commands[0] == "ChangeAll")
                {
                    text = text.Replace(commands[1], commands[2]);
                }

                if (isFlag)
                {
                    Console.WriteLine(text);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {text}");

        }
    }
}
