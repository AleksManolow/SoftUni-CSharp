using System;

namespace task01_Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "Done")
            {
                if (input[0] == "TakeOdd")
                {
                    string newPass = "";
                    for (int i = 1; i < password.Length; i+=2)
                    {
                        newPass += password[i];
                    }
                    password = newPass;
                    Console.WriteLine(password);
                }
                else if (input[0] == "Cut")
                {
                    password = password.Remove(int.Parse(input[1]), int.Parse(input[2]));
                    Console.WriteLine(password);
                }
                else if (input[0] == "Substitute")
                {
                    if (password.Contains(input[1]))
                    {
                        password = password.Replace(input[1], input[2]);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }

                input = Console.ReadLine().Split();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
