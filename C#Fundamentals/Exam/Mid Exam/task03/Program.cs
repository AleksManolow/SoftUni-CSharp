using System;
using System.Collections.Generic;

namespace task03
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();
            List<string> message = new List<string>();
            while (command[0] != "end")
            {
                if (command[0] == "Chat")
                {
                    message.Add(command[1]);
                }
                else if (command[0] == "Delete" && message.Contains(command[1]))
                {
                    message.Remove(command[1]);
                }
                else if (command[0] == "Edit" && message.Contains(command[1]))
                {
                    for (int i = 0; i < message.Count; i++)
                    {
                        if (message[i] == command[1])
                        {
                            message[i] = command[2];
                        }
                    }
                }
                else if (command[0] == "Pin" && message.Contains(command[1]))
                {
                    for (int i = 0; i < message.Count; i++)
                    {
                        if (message[i] == command[1])
                        {
                            message.RemoveAt(i);
                            message.Add(command[1]);
                        }
                    }
                }
                else if (command[0] == "Spam")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        message.Add(command[i]);
                    }
                }
                command = Console.ReadLine().Split();
            }
            for (int i = 0; i < message.Count; i++)
            {
                Console.WriteLine(message[i]);
            }

        }
    }
}
