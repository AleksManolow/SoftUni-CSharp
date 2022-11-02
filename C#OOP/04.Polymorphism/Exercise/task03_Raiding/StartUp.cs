using System;
using System.Collections.Generic;
using System.Linq;

namespace task03_Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> raidGroup = new List<BaseHero>();

            
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                BaseHero hero = null;
                switch (type)
                {
                    case "Druid":
                        hero = new Druid(name);
                        raidGroup.Add(hero);
                        break;
                    case "Paladin":
                        hero = new Paladin(name);
                        raidGroup.Add(hero);
                        break;
                    case "Rogue":
                        hero = new Rogue(name);
                        raidGroup.Add(hero);
                        break;
                    case "Warrior":
                        hero = new Warrior(name);
                        raidGroup.Add(hero);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }
            int bossPower = int.Parse(Console.ReadLine());

            int sum = 0;
            foreach (var baseHero in raidGroup)
            {
                Console.WriteLine(baseHero.CastAbility());
                sum += baseHero.Power;
            }
            Console.WriteLine(sum >= bossPower
                ? "Victory!"
                : "Defeat...");
        }
    }
}
