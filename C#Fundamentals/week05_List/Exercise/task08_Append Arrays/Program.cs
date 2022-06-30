using System;
using System.Collections.Generic;
using System.Linq;

namespace task08_Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listStringInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "3:1")
            {
                int startIndex = int.Parse(command[1]);
                int endIndex = int.Parse(command[2]);
                if (endIndex > listStringInput.Count - 1 || endIndex < 0)
                {
                    endIndex = listStringInput.Count - 1;
                }

                if (startIndex < 0 || startIndex > listStringInput.Count - 1)
                {
                    startIndex = 0;
                }

                if (command[0] == "merge")
                {
                    mergeFun(listStringInput, startIndex , endIndex);
                }
                else if (command[0] == "divide")
                {
                    List<string> divided = new List<string>();
                    int partitions = int.Parse(command[2]);
                    string word = listStringInput[startIndex];
                    listStringInput.RemoveAt(startIndex);
                    int part = word.Length / partitions;
                    for (int i = 0; i < partitions; i++)
                    {
                        if (partitions - 1 == i)
                        {
                            divided.Add(word.Substring(i * part));
                        }
                        else
                        {
                            divided.Add(word.Substring(i * part, part));
                        }
                    }
                    listStringInput.InsertRange(startIndex, divided);

                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", listStringInput));
        }

        private static void mergeFun(List<string> listStringInput, int start, int end)
        {
            string temp = "";
            for (int i = start; i <= end; i++)
            {
                temp = temp + listStringInput[i];
            }
            listStringInput.RemoveRange(start, end - start + 1);
            listStringInput.Insert(start, temp);
        }
    }
}
