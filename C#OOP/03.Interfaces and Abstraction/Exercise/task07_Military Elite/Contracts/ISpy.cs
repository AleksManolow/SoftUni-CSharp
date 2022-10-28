using System;
using System.Collections.Generic;
using System.Text;

namespace task07_Military_Elite.Contracts
{
    public interface ISpy:ISoldier
    {
        public int CodeNumber { get; set; }
    }
}
