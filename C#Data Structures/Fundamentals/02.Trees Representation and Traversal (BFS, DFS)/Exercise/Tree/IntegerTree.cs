namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var result = new List<List<int>>();

            var currentPath = new LinkedList<int>();
            currentPath.AddFirst(this.Key);
            int currSum = this.Key;
            this.Dfs(this, result, currentPath,ref currSum, sum);

            return result;
        }

        private void Dfs(Tree<int> subtree,
            List<List<int>> result,
            LinkedList<int> currentPath, 
            ref int currSum, 
            int wantedSum)
        {
            foreach (var child in subtree.Children)
            {
                currSum += child.Key;
                currentPath.AddLast(child.Key);
                this.Dfs(child, result, currentPath,ref currSum, wantedSum);
            }

            if (subtree.Children.Count == 0 && wantedSum == currSum)
            {
                result.Add(new List<int>(currentPath));
            }

            currSum -= subtree.Key;
            currentPath.RemoveLast();
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }
    }
}
