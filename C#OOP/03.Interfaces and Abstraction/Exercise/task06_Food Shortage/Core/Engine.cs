using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using task06_Food_Shortage.Model;

namespace task06_Food_Shortage
{
    public class Engine
    {
        Dictionary<string, IBuyer> repository = new Dictionary<string, IBuyer>();
        public Engine()
        {
            this.repository = new Dictionary<string, IBuyer>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            CreateIBuyer(n);

            string inutNames = Console.ReadLine();
            while (inutNames != "End")
            {
                BuyingByNames(inutNames);

                inutNames = Console.ReadLine();
            }

            CalculateAndPrintTotalFoodBought();
        }

        private void CalculateAndPrintTotalFoodBought()
        {

            Console.WriteLine(repository.Values.Sum(x => x.Food));
        }

        private void BuyingByNames(string name)
        {
            if (repository.ContainsKey(name))
            {
                repository[name].BuyFood();
            }
        }

        private void CreateIBuyer(int n)
        {
            IBuyer buyer = null;
            for (int i = 0; i < n; i++)
            {
                string[] inputTokens = Console.ReadLine().Split(' ');   
                if (inputTokens.Length == 4)
                {
                    string name = inputTokens[0];
                    int age = int.Parse(inputTokens[1]);
                    string id = inputTokens[2];
                    string birthdate = inputTokens[3];
                    buyer = new Citizen(name, age, id, birthdate);
                }
                else
                {
                    string name = inputTokens[0];
                    int age = int.Parse(inputTokens[1]);
                    string group = inputTokens[2];

                    buyer = new Rebel(name, age, group);
                }
                repository.Add(inputTokens[0], buyer);
            }
            
        }
    }
}
