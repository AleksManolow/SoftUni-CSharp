using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using task07_Military_Elite.Contracts;

namespace task07_Military_Elite.Model
{
    public class Private : Solder, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString()
        => $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}";
    }
}
