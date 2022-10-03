using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class ListyIterator<T>
    {
        private List<T> elements;
        private int index;

        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
            this.index = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }
            return false;
        }
        public bool HasNext() 
            => index + 1 < elements.Count;  

        public void Print()
        {
            if (elements.Count == 0)
            {
                throw new Exception("Invalid Operation!");
            }
            Console.WriteLine(elements[index]);
        }

    }
}
