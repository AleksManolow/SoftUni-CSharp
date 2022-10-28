using System;
using System.Collections.Generic;
using System.Text;

namespace task07_Military_Elite.Contracts
{
    public interface ICommando:ISpecialisedSoldier
    {
        public List<IMission> Missions { get; set; }
    }
}
