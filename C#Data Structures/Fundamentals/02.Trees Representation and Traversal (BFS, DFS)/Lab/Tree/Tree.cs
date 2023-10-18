namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        private T value;
        private Tree<T> parent;
        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindNodeWithBfs(parentKey);
            if (parentNode == null)
            {
                throw new ArgumentNullException();
            }
            parentNode.children.Add(child);
            child.parent = parentNode;
        }

        private Tree<T> FindNodeWithBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                if (subtree.value.Equals(parentKey))
                {
                    return subtree;
                }
                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
        }

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.value);

                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var stack = new Stack<Tree<T>>();
            var result = new Stack<T>();

            stack.Push(this);

            while (stack.Count > 0)
            {
                var subtree = stack.Pop();
                foreach (var child in subtree.children)
                {
                    stack.Push(child);
                }
                result.Push(subtree.value);
            }
            return result;
        }

        public void RemoveNode(T nodeKey)
        {
            var toBeDeleteNode = this.FindNodeWithBfs(nodeKey);
            if (toBeDeleteNode == null)
            {
                throw new ArgumentNullException();
            }
            var parenNode = toBeDeleteNode.parent;
            if (parenNode == null)
            {
                throw new ArgumentException();
            }
            parenNode.children = parenNode.children.Where(x => !x.value.Equals(nodeKey)).ToList();
            toBeDeleteNode.parent = null;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstKeyToBeSwap = this.FindNodeWithBfs(firstKey);
            var secondKeyToBeSwap = this.FindNodeWithBfs(secondKey);
            if (firstKeyToBeSwap == null || secondKeyToBeSwap == null)
            {
                throw new ArgumentNullException();
            }

            var firstParen = firstKeyToBeSwap.parent;
            var secondParen = secondKeyToBeSwap.parent;
            if (firstParen == null || secondKey == null)
            {
                throw new ArgumentException();
            }

            int indexOfFirstChild = firstParen.children.IndexOf(firstKeyToBeSwap);
            int indexOfSecondChild = secondParen.children.IndexOf(secondKeyToBeSwap);

            firstParen.children[indexOfFirstChild] = secondKeyToBeSwap;
            secondKeyToBeSwap.parent = firstParen;
            secondParen.children[indexOfSecondChild] = firstKeyToBeSwap;
            firstKeyToBeSwap.parent = secondParen;
        }
    }
}
