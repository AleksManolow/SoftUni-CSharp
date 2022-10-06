using System;

namespace task01_The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] inputOperations = Console.ReadLine().Split('|');
            while (inputOperations[0] != "Decode")
            {
                if (inputOperations[0] == "Move")
                {
                    text += text.Substring(0, int.Parse(inputOperations[1]));
                    text = text.Remove(0, int.Parse(inputOperations[1]));
                }
                else if (inputOperations[0] == "Insert")
                {
                    text = text.Substring(0, int.Parse(inputOperations[1])) + inputOperations[2] + text.Substring(int.Parse(inputOperations[1]));
                }
                else if (inputOperations[0] == "ChangeAll")
                {
                    text = text.Replace(inputOperations[1], inputOperations[2]);
                }

                inputOperations = Console.ReadLine().Split('|');
            }
            Console.WriteLine($"The decrypted message is: {text}");
        }
    }
}
