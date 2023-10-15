namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(T element)
            {
                Element = element;
            }
        }
        private Node head;
        private Node tail; 

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node node = new Node(item);
            if (tail == null)
            {
                this.tail = node;
            }
            else
            {
                node.Next = this.head;
                this.head.Prev = node;
            }
            this.head = node;
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node node = new Node(item);
            if (head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.Next = node;
                node.Prev = this.tail;
            }
            this.tail = node;
            this.Count++;
        }

        public T GetFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
            return this.head.Element;
        }

        public T GetLast()
        {
            if (this.tail == null)
            {
                throw new InvalidOperationException();
            }
            return this.tail.Element;
        }

        public T RemoveFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
            Node tempNode = this.head;
            
            if (this.head == this.tail)
            {
                this.head = this.tail = null;
            }
            else
            {
                head = head.Next;
                head.Prev = null;
            }
            Count--;
            return tempNode.Element;
        }

        public T RemoveLast()
        {
            if (this.tail == null)
            {
                throw new InvalidOperationException();
            }
            Node tempNode = this.tail;
            if (this.head == this.tail)
            {
                this.head = this.tail = null;
            }
            else
            {
                tail = tail.Prev;
                tail.Next = null;
            }
            Count--;
            return tempNode.Element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = this.head;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}