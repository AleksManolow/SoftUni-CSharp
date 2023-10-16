namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> chars = new Stack<char>();
            for (int i = 0; i < parentheses.Length; i++)
            {
                if (chars.Count != 0 && 
                    ((chars.Peek() == '[' && parentheses[i] == ']')
                    || (chars.Peek() == '{' && parentheses[i] == '}')
                    || (chars.Peek() == '(' && parentheses[i] == ')')))
                {
                    chars.Pop();
                }
                else
                {
                    chars.Push(parentheses[i]);
                }
            }
            return chars.Count == 0;
        }
    }
}
