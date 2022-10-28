using System;
using System.Collections.Generic;
using System.Text;

namespace task07_Military_Elite.Contracts
{
    public interface IRepair
    {
        public string PartName { get; set; }
        public int HoursWorked { get; set; }
    }
}
