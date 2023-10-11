namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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
        private Node head;
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node node = new Node(item, head);
            this.head = node;
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);
            if (head == null)
            {
                this.head = newNode;
            }
            else
            {
                Node node = this.head;
                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = newNode;
            }

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
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
            Node node = this.head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            return node.Element;
        }

        public T RemoveFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
            var oldHead = this.head;
            this.head = this.head.Next;
            this.Count--;
            return oldHead.Element;
        }

        public T RemoveLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
            Node endNode;
            if (Count == 1)
            {
                endNode = this.head;    
                head = null;
            }
            else
            {
                Node node = this.head;
                while (node.Next.Next != null)
                {
                    node = node.Next;
                }
                endNode = node.Next;
                node.Next = null;
            }
            
            this.Count--;
            
            return endNode.Element;
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
            => this.GetEnumerator();
    }
}