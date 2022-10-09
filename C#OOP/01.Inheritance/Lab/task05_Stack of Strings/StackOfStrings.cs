using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings:Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }
            return false;
        }

        public Stack<string> AddRange(IEnumerable<string> items)
        {

            foreach (var item in items)
            {
                this.Push(item);
            }
            return this;
        }

    }
}
