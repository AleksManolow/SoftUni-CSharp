using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> box;

        public Box()
        {
            box = new List<T>();
        }

        public void Add (T element)
        {
            box.Insert(0, element);
        }

        public T Remove()
        {
            T removedEment = box[0];
            box.RemoveAt(0);
            return removedEment;
        }

        public int Count => box.Count;

    }
}
