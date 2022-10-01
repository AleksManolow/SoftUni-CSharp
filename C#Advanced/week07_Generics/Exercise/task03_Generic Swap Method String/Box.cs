using System;
using System.Collections.Generic;
using System.Text;

namespace task03_Generic_Swap_Method_String
{
    public class Box<T>
    {
        public T Element { get; set; }
        public List<T> Elements { get; set; }

        public Box(T element)
        {
            this.Element = element;
        }
        public Box(List<T> elements)
        {
            this.Elements = elements;
        }
        public void Swap(List<T> elementsList, int index01, int index02)
        {
            T firstElement = elementsList[index01];
            elementsList[index01] = elementsList[index02];
            elementsList[index02] = firstElement;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Elements)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString();
        }
    }
}
