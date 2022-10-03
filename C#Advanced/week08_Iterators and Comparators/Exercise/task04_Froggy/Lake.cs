using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace task04_Froggy
{
    public class Lake:IEnumerable<int>
    {
        private List<int> elements;

        public Lake(List<int> elements)
        {
            this.elements = elements;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return elements[i];
                }
            }

            for (int i = elements.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return elements[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();
    }
}
