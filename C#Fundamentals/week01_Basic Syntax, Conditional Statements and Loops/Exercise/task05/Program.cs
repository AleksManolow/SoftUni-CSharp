using System;

namespace task05
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            int count = 0;
            string pass = "";
            for (int i = username.Length - 1; i >= 0 ; i--)
            {
                pass += username[i];
            }

            int curr = 0;
            while (true)
            {
                string tryPass = Console.ReadLine();
                curr++;
                if (tryPass == pass)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                if (curr == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                Console.WriteLine($"Incorrect password. Try again.");
            }


            
        }
    }
}
