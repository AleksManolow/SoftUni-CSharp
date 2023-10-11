namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            items = new T[capacity];
        }

        public T this[int index] 
        { 
            get
            {
                this.ValidateIndex(index);
                return this.items[index];
            }
            set 
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }

        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.Grow();
            items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            foreach (var it in items.Take(this.Count))
            {
                if (it.Equals(item))
                    return true;
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.Grow();

            for (int i = this.Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index == -1) return false;
            else
            {
                this.RemoveAt(index);
                return true;
            }
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            this.items[--this.Count] = default(T);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void Grow()
        {
            if (this.Count == items.Length)
            {
                T[] itemsCopy = new T[this.items.Length * 2];
                for (int i = 0; i < this.items.Length; i++)
                {
                    itemsCopy[i] = items[i];
                }
                items = itemsCopy;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Invalid Index Given");
            }
        }
    }
}