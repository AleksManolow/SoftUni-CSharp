using System;
using System.Collections.Generic;
using System.Text;

namespace task07_Military_Elite.Contracts
{
    public interface ILieutenantGeneral:IPrivate
    {
        public List<IPrivate> Privates { get; set; }

    }
}
