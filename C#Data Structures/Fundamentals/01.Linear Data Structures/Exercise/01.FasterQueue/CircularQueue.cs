namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;
        private int startIndex, endIndex;
        public CircularQueue(int capacity = 4)
        {
            this.elements = new T[capacity];
            this.Count = 0;
        }
        public int Count { get; private set; }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException("Invalid");
            }
            T oddElement = this.elements[startIndex];
            this.startIndex = (startIndex + 1) % this.elements.Length;
            this.Count--;
            return oddElement;
        }

        public void Enqueue(T item)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.endIndex] = item;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        private void Grow()
        {
            this.elements = this.CopyElemets(new T[this.elements.Length * 2]);
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private T[] CopyElemets(T[] resultArr)
        {
            for (int i = 0; i < this.Count; i++)
            {
                resultArr[i] = this.elements[(startIndex + i) % this.elements.Length];
            }
            return resultArr;
        }

        public T Peek()
        {
            if (this.Count == 0)
            { 
                throw new IndexOutOfRangeException("Invalid");
            }
            return elements[this.startIndex];
        }

        public T[] ToArray()
        {
            return this.CopyElemets(new T[this.Count]);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[(this.startIndex + i) % this.elements.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }

}
