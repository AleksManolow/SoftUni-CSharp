using System;
using System.Collections.Generic;
using System.Text;
using task07_Military_Elite.Contracts;
using task07_Military_Elite.Enums;

namespace task07_Military_Elite.Model
{
    public class Engineer:SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps)
    : base(id, firstName, lastName, salary, corps)
        {
            Repairs = new List<IRepair>();
        }

        public List<IRepair> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");

            foreach (var item in Repairs)
            {
                sb.AppendLine($"  {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

