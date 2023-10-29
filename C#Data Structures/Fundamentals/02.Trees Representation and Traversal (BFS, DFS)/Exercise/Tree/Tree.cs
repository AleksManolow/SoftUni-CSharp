namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> childern;
        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.childern = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.childern.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            childern.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent; 
        }

        public string AsString()
        {
            var sb = new StringBuilder();

            this.DfsAsString(sb, this, 0);

            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent)
                .AppendLine(tree.Key.ToString());

            foreach (var child in tree.childern)
            {
                this.DfsAsString(sb, child, indent + 1);
            }
        }

        public IEnumerable<T> GetInternalKeys()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                if (curr.childern.Count > 0 && curr.Parent != null)
                {
                    result.Add(curr.Key);
                }
                foreach (var child in curr.childern)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        public IEnumerable<T> GetLeafKeys()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                if (curr.childern.Count == 0)
                {
                    result.Add(curr.Key);
                }
                foreach (var child in curr.childern)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }

        public T GetDeepestKey()
        {
            return this.GetDeepestNode(this).Key;
        }

        private Tree<T> GetDeepestNode(Tree<T> key)
        {
            var leafs = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                if (curr.childern.Count == 0)
                {
                    leafs.Add(curr);
                }
                foreach (var child in curr.childern)
                {
                    queue.Enqueue(child);
                }
            }

            Tree<T> deepesNode = null;
            var maxDepth = 0;
            foreach (var leaf in leafs)
            {
                var depth = this.GetDeth(leaf);
                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepesNode = leaf;
                }
            }
            return deepesNode;
        }

        private int GetDeth(Tree<T> leaf)
        {
            int depth = 0;
            var tree = leaf;
            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }
            return depth;
        }
        private Stack<T> GetPathDeth(Tree<T> leaf)
        {
            Stack<T> longestPath = new Stack<T>();
            longestPath.Push(leaf.Key);
            var tree = leaf;
            while (tree.Parent != null)
            {
                tree = tree.Parent;
                longestPath.Push(tree.Key);
            }
            return longestPath;
        }

        public IEnumerable<T> GetLongestPath()
        {
            var leafs = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                if (curr.childern.Count == 0)
                {
                    leafs.Add(curr);
                }
                foreach (var child in curr.childern)
                {
                    queue.Enqueue(child);
                }
            }

            Stack<T> longestPath = null;
            var maxDepth = 0;
            foreach (var leaf in leafs)
            {
                var depth = this.GetPathDeth(leaf);
                if (depth.Count > maxDepth)
                {
                    maxDepth = depth.Count;
                    longestPath = depth;
                }
            }
            return longestPath;
        }
    }
}
