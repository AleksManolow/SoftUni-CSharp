using System;
using System.Collections.Generic;

namespace task03_The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string[]> pieces = new Dictionary<string, string[]>();

            for (int i = 0; i < n; i++)
            {
                string[] piecesThemselves = Console.ReadLine().Split('|');
                string[] tempArr = { piecesThemselves[1], piecesThemselves[2] };
                pieces.Add(piecesThemselves[0], tempArr);
            }

            string[] inputOperations = Console.ReadLine().Split('|');
            while (inputOperations[0] != "Stop")
            {
                if (inputOperations[0] == "Add")
                {
                    if (pieces.ContainsKey(inputOperations[1]))
                    {
                        Console.WriteLine($"{inputOperations[1]} is already in the collection!");
                    }
                    else
                    {
                        string[] tempArr = { inputOperations[2], inputOperations[3] };
                        pieces.Add(inputOperations[1], tempArr);
                        Console.WriteLine($"{inputOperations[1]} by {inputOperations[2]} in {inputOperations[3]} added to the collection!");
                    }
                }
                else if (inputOperations[0] == "Remove")
                {
                    if (pieces.ContainsKey(inputOperations[1]))
                    {
                        pieces.Remove(inputOperations[1]);
                        Console.WriteLine($"Successfully removed {inputOperations[1]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {inputOperations[1]} does not exist in the collection.");
                    }
                }
                else if (inputOperations[0] == "ChangeKey")
                {
                    if (pieces.ContainsKey(inputOperations[1]))
                    {
                        pieces[inputOperations[1]][1] = inputOperations[2];
                        Console.WriteLine($"Changed the key of {inputOperations[1]} to {inputOperations[2]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {inputOperations[1]} does not exist in the collection.");
                    }
                }
                inputOperations = Console.ReadLine().Split('|');
            }
            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
