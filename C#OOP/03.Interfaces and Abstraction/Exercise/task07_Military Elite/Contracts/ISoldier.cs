using System;
using System.Collections.Generic;
using System.Text;

namespace task07_Military_Elite.Contracts
{
    public interface ISoldier
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
