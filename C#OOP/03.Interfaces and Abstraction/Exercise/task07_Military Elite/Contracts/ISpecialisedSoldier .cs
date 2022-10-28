using System;
using System.Collections.Generic;
using System.Text;
using task07_Military_Elite.Enums;

namespace task07_Military_Elite.Contracts
{
    public interface ISpecialisedSoldier:IPrivate
    {
        public Corps Corps { get; set; }
    }
}
