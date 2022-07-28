using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace task05_Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string healthPattern = @"[^\+\-\*\/\.,0-9]";
            string demagePattern = @"-?\d+\.?\d*";
            string multiplyPattern = @"[\*\/]";
            string splitPattern = @"[,\s]+";

            string input = Console.ReadLine();
            string[] demons = Regex.Split(input, splitPattern).OrderBy(x => x).ToArray();

            for (int i = 0; i < demons.Length; i++)
            {
                string currDemon = demons[i];
                MatchCollection healthMatch = Regex.Matches(currDemon, healthPattern);
                int health = 0;
                foreach (Match match in healthMatch)
                {
                    char curChar = char.Parse(match.ToString());
                    health += curChar;
                }

                double damage = 0;
                MatchCollection damageMatched = Regex.Matches(currDemon, demagePattern);
                foreach (Match match in damageMatched)
                {
                    double currDamage = double.Parse(match.ToString());
                    damage += currDamage;
                }

                
                MatchCollection multyplyMatched = Regex.Matches(currDemon, multiplyPattern);
                foreach (Match match in multyplyMatched)
                {
                    char currOperator = char.Parse(match.ToString());
                    if (currOperator == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }
                Console.WriteLine($"{currDemon} - {health} health, {damage:F2} damage");
            }

        }
    }
}
