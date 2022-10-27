using System;
using System.Collections.Generic;
using System.Text;

namespace task06_Food_Shortage
{
    public class Citizen:IIdentifiable,IBirthdate, IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = 0;
        }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
