using System;
using System.Collections.Generic;
using System.Text;
using task07_Military_Elite.Contracts;
using task07_Military_Elite.Enums;

namespace task07_Military_Elite.Model
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; set; }
        

        
    }
}
