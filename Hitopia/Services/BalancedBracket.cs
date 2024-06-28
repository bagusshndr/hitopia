using System;
using System.Collections.Generic;

namespace mdoule.Services
{
    public class BalancedBracketService
    {
        public string IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char ch in input)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == ']' || ch == '}')
                {
                    if (stack.Count == 0 || !IsMatchingPair(stack.Pop(), ch))
                    {
                        return "NO";
                    }
                }
            }
            return stack.Count == 0 ? "YES" : "NO";
        }

        private bool IsMatchingPair(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '[' && close == ']') ||
                   (open == '{' && close == '}');
        }
    }
}
