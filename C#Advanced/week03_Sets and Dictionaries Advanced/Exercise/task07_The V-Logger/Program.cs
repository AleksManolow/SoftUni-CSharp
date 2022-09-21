using System;
using System.Collections.Generic;
using System.Linq;

namespace task07_The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> vloggers = new List<Vlogger>();
            
            string[] input = Console.ReadLine().Split(' '); 
            while (input[0] != "Statistics")
            {
                if (input[1] == "joined")
                {
                    if (!vloggers.Any(x => x.Name == input[0]))
                    {
                        vloggers.Add(new Vlogger(input[0]));
                    }
                }
                else if (input[1] == "followed")
                {
                    if (input[0] == input[2]
                        || !vloggers.Any(x => x.Name == input[0])
                        || !vloggers.Any(x => x.Name == input[2]))
                    {

                    }
                    else
                    {
                        Vlogger vlogger = vloggers.Single(v => v.Name == input[0]);
                        vlogger.Following.Add(input[2]);

                        Vlogger vloggerToFollow = vloggers.Single(v => v.Name == input[2]);
                        vloggerToFollow.Followers.Add(input[0]);
                    }
                }
                input = Console.ReadLine().Split(' ');
            }
            vloggers = vloggers
                .OrderByDescending(x => x.Followers.Count)
                .ThenBy(x => x.Following.Count)
                .ToList();

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int count = 1;
            foreach (var vlogger in vloggers)
            {
                Console.WriteLine($"{count}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
                if (count == 1)
                {
                    foreach (var f in vlogger.Followers)
                    {
                        Console.WriteLine($"*  {f}");
                    }
                }
                count++;
            }
        }

    }
    public class Vlogger
    { 
        public string Name { get; set; }
        public SortedSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }

        public Vlogger(string name)
        {
            Name = name;
            Followers = new SortedSet<string>();
            Following = new HashSet<string>();
        }
    }

}
