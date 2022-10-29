using System;
using System.Collections.Generic;
using System.Text;
using task07_Military_Elite.Contracts;

namespace task07_Military_Elite.Model
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }
        public string PartName { get; set; }
        public int HoursWorked { get; set; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
