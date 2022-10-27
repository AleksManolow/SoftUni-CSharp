using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task04_Border_Control
{
    public class Engine
    {
        List<IIdentifiable> repository;

        public Engine()
        {
            this.repository = new List<IIdentifiable>();
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


            string fakeId = Console.ReadLine();
            string[] fakeIds = repository.Where(x => x.Id.EndsWith(fakeId)).Select(x => x.Id).ToArray();
            PrintFinalResult(fakeIds);
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

            IIdentifiable identifiable;
            if (inputTokens.Length == 3)
            {
                string name = inputTokens[0];
                int age = int.Parse(inputTokens[1]);
                string id = inputTokens[2];

                identifiable = new Citizen(name, age, id);
                
            }
            else
            {
                string name = inputTokens[0];
                string id = inputTokens[1];

                identifiable = new Robot(name, id);
            }
            this.repository.Add(identifiable);
        }
    }
}
