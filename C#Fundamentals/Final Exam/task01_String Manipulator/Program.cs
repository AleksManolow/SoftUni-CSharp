using System;

namespace task01_String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End" )
            {
                if (command[0] == "Translate")
                {
                    text = text.Replace(command[1], command[2]);
                    Console.WriteLine(text);
                }
                else if (command[0] == "Includes")
                {
                    Console.WriteLine(text.Contains(command[1]));
                }
                else if (command[0] == "Start")
                {
                    Console.WriteLine(text.IndexOf(command[1]) == 0);
                }
                else if (command[0] == "Lowercase")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (command[0] == "FindIndex")
                {
                    Console.WriteLine(text.LastIndexOf(command[1]));
                }
                else if (command[0] == "Remove")
                {
                    text = text.Remove(int.Parse(command[1]), int.Parse(command[2]));
                    Console.WriteLine(text);
                }
                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            
        }
    }
}
