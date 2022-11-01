using System;
using System.Collections.Generic;
using System.Text;

namespace task09_Explicit_Interfaces.Contracts
{
    public interface IResident
    {
        public string Name { get; set; }
        public string Country { get; set; }
        string GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
