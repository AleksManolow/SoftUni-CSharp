using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task05_Birthday_Celebrations
{
    public class Engine
    {
        List<IBirthdate> repository;

        public Engine()
        {
            this.repository = new List<IBirthdate>();
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputTokens = input.Split(' ');

                CreateIdentifiable(inputTokens);

                input = Console.ReadLine();
            }


            string searchYear = Console.ReadLine();
            string[] searchYears = repository.Where(x => x.Birthdate.EndsWith(searchYear)).Select(x => x.Birthdate).ToArray();
            PrintFinalResult(searchYears);
        }

        private void PrintFinalResult(string[] fakeIds)
        {
            foreach (var fakeId in fakeIds)
            {
                Console.WriteLine(fakeId);
            }
        }

        private void CreateIdentifiable(string[] inputTokens)
        {

            IBirthdate ibirthdate = null;
            if (inputTokens[0] == "Citizen")
            {
                string name = inputTokens[1];
                int age = int.Parse(inputTokens[2]);
                string id = inputTokens[3];
                string birthdate = inputTokens[4];

                ibirthdate = new Citizen(name, age, id, birthdate);
                
            }
            else if(inputTokens[0] == "Pet")
            {
                string name = inputTokens[1];
                string birthdate = inputTokens[2];

                ibirthdate = new Pet(name, birthdate);
            }

            if (ibirthdate != null)
            {
                this.repository.Add(ibirthdate);
            }
            
        }
    }
}
