namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }
            public Node(T element)
            {
                Element = element;
            }
        }

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            Node node = new Node(item, this.top);
            this.top = node;
            this.Count++;
        }

        public T Pop()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }
            var oldTop = this.top;
            this.top = this.top.Next;
            this.Count--;
            return oldTop.Element;
        }

        public T Peek()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }
            return this.top.Element;
        }

        public bool Contains(T item)
        {
            Node node = this.top;
            while (node != null)
            {
                if (node.Element.Equals(item))
                    return true;
                node = node.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.top;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}