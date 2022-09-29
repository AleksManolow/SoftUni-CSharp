using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputTrainers = Console.ReadLine().Split(' ');
            List<Trainer> trainers = new List<Trainer>();
            while (inputTrainers[0] != "Tournament")
            {

                if (trainers.SingleOrDefault(x => x.Name == inputTrainers[0]) == null)
                {
                    trainers.Add(new Trainer(inputTrainers[0]));
                }
                trainers
                    .Single(x => x.Name == inputTrainers[0])
                    .Pokemons
                    .Add(new Pokemon(inputTrainers[1], inputTrainers[2], int.Parse(inputTrainers[3])));
                inputTrainers = Console.ReadLine().Split(' ');
            }

            string inputElements = Console.ReadLine();
            while (inputElements != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Where(x => x.Element == inputElements).Count() == 0)
                    {
                        
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;
                        }
                        trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                    else
                    {
                        trainer.NumberOfBadges += 1;
                    }
                }
                inputElements = Console.ReadLine();
            }
            trainers = trainers.OrderByDescending(x => x.NumberOfBadges).ToList();

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
