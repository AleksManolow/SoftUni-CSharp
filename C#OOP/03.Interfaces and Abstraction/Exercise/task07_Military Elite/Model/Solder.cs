using System;
using System.Collections.Generic;
using System.Text;
using task07_Military_Elite.Contracts;

namespace task07_Military_Elite.Model
{
    public abstract class Solder : ISoldier
    {
        public Solder(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get ; set; }

        public override string ToString()
        => $"Name: {FirstName} {LastName} Id: {Id}";
    }
}
