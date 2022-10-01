using System;
using System.Collections.Generic;
using System.Text;

namespace task08_Threeuple
{
    internal class Threeuple<T, U, V>
    { 
        public T Item1 { get; set; }
        public U Item2 { get; set; }

        public V Item3 { get; set; }

        public Threeuple(T item1, U item2, V item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }
        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }
}
