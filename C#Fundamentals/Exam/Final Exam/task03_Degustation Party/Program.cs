using System;
using System.Collections.Generic;

namespace task03_Degustation_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, GuestInformation> guests = new Dictionary<string, GuestInformation>();
            string[] input = Console.ReadLine().Split('-');
            while (input[0] != "Stop")
            {
                if (input[0] == "Like")
                {
                    if (!guests.ContainsKey(input[1]))
                    {
                        GuestInformation guestInf = new GuestInformation();
                        guests.Add(input[1], guestInf);
                    }

                    if (!guests[input[1]].LikesMeal.Contains(input[2]))
                    {
                        guests[input[1]].LikesMeal.Add(input[2]);
                    }
                }
                else if (input[0] == "Dislike")
                {
                    if (guests.ContainsKey(input[1]) && guests[input[1]].LikesMeal.Contains(input[2]))
                    {
                        Console.WriteLine($"{input[1]} doesn't like the {input[2]}.");
                        guests[input[1]].LikesMeal.Remove(input[2]);
                        guests[input[1]].countDislikeMeal++;
                    }
                    else if (!guests.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"{input[1]} is not at the party.");
                    }
                    else if (!guests[input[1]].LikesMeal.Contains(input[2]))
                    {
                        Console.WriteLine($"{input[1]} doesn't have the {input[2]} in his/her collection.");
                    }
                }

                input = Console.ReadLine().Split('-');
            }
            int sumUnlikedMeals = 0;
            foreach (var guest in guests)
            {
                Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value.LikesMeal)}");
                sumUnlikedMeals += guest.Value.countDislikeMeal;
            }
            Console.WriteLine($"Unliked meals: {sumUnlikedMeals}");
        }
    }
    class GuestInformation
    {
        public List<string> LikesMeal { get; set; } = new List<string>();
        public int countDislikeMeal { get; set; }
    }
}
