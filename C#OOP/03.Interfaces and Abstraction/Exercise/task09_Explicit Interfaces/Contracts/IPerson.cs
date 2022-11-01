using System;
using System.Collections.Generic;
using System.Text;

namespace task09_Explicit_Interfaces.Contracts
{
    public interface IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        string GetName()
        {
            return this.Name;
        }
    }
}
