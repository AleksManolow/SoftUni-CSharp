using System;

namespace task01_Submit_a_solution
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            foreach (string username in usernames)
            {
                bool isValid = true;
                if (username.Length > 3 && username.Length < 16)
                {
                    for (int i = 0; i < username.Length; i++)
                    {
                        if (!(char.IsDigit(username[i]) || char.IsLetter(username[i]) || username[i] == '_' || username[i] == '-'))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        Console.WriteLine(username);
                    }
                }
            }
        }
    }
}
