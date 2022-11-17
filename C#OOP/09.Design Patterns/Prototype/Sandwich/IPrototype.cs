using System;
using System.Collections.Generic;
using System.Text;

namespace Sandwich
{
    public interface IPrototype<T>
    {
        T ShallowCopy();
        T DeepCopy();
    }
}
