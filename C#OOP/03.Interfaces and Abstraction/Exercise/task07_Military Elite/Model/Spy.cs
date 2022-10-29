using System;
using System.Collections.Generic;
using System.Text;
using task07_Military_Elite.Contracts;

namespace task07_Military_Elite.Model
{
    public class Spy:Solder,ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }
        public int CodeNumber { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id}");
            sb.AppendLine($"Code Number: {CodeNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}
