using System;
using System.Collections.Generic;
using System.Text;

namespace task08_Collection_Hierarchy.Contracts
{
    public interface IAddAndRemove:IAddCollection
    {
        string Remove();
    }
}
