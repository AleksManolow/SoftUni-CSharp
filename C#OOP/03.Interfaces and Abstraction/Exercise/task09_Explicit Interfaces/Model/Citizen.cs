using System;
using System.Collections.Generic;
using System.Text;
using task09_Explicit_Interfaces.Contracts;

namespace task09_Explicit_Interfaces.Model
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
    }
}
