using System;
using System.Collections.Generic;

namespace task03_Heroes_of_Code_and_Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, HeroInformation> heroes = new Dictionary<string, HeroInformation>();

            for (int i = 0; i < n; i++)
            {
                string[] inputHeroe = Console.ReadLine().Split();
                HeroInformation hero = new HeroInformation(int.Parse(inputHeroe[1]), int.Parse(inputHeroe[2]));
                heroes.Add(inputHeroe[0], hero);
            }

            string[] inputCommands = Console.ReadLine().Split(" - ",StringSplitOptions.RemoveEmptyEntries);
            while (inputCommands[0] != "End")
            {
                if (inputCommands[0] == "CastSpell")
                {
                    if (heroes[inputCommands[1]].MP >= int.Parse(inputCommands[2]))
                    {
                        heroes[inputCommands[1]].MP -= int.Parse(inputCommands[2]);
                        Console.WriteLine($"{inputCommands[1]} has successfully cast {inputCommands[3]} and now has {heroes[inputCommands[1]].MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{inputCommands[1]} does not have enough MP to cast {inputCommands[3]}!");
                    }
                }
                else if (inputCommands[0] == "TakeDamage")
                {
                    if (heroes[inputCommands[1]].HP > int.Parse(inputCommands[2]))
                    {
                        heroes[inputCommands[1]].HP -= int.Parse(inputCommands[2]);
                        Console.WriteLine($"{inputCommands[1]} was hit for {inputCommands[2]} HP by {inputCommands[3]} and now has {heroes[inputCommands[1]].HP} HP left!");
                    }
                    else
                    {
                        heroes.Remove(inputCommands[1]);
                        Console.WriteLine($"{inputCommands[1]} has been killed by {inputCommands[3]}!");
                    }
                }
                else if (inputCommands[0] == "Recharge")
                {
                    if (heroes[inputCommands[1]].MP + int.Parse(inputCommands[2]) > 200)
                    {
                        
                        Console.WriteLine($"{inputCommands[1]} recharged for {200 - heroes[inputCommands[1]].MP} MP!");
                        heroes[inputCommands[1]].MP = 200;
                    }
                    else
                    {
                        heroes[inputCommands[1]].MP += int.Parse(inputCommands[2]);
                        Console.WriteLine($"{inputCommands[1]} recharged for {inputCommands[2]} MP!");
                    }
                }
                else if (inputCommands[0] == "Heal")
                {
                    if (heroes[inputCommands[1]].HP + int.Parse(inputCommands[2]) > 100)
                    {

                        Console.WriteLine($"{inputCommands[1]} healed for {100 - heroes[inputCommands[1]].HP} HP!");
                        heroes[inputCommands[1]].HP = 100;
                    }
                    else
                    {
                        heroes[inputCommands[1]].HP += int.Parse(inputCommands[2]);
                        Console.WriteLine($"{inputCommands[1]} healed for {inputCommands[2]} HP!");
                    }
                }

                inputCommands = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }
    }
    class HeroInformation
    {
        public int HP { get; set; }
        public int MP { get; set; }
        public HeroInformation(int hp, int mp)
        {
            this.HP = hp;
            this.MP = mp;
        }
    }
}

