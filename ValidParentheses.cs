//https://leetcode.com/problems/valid-parentheses/
using NUnit.Framework;

namespace LeetCode
{
    [TestFixture]
    public class ValidParentheses
    {
        private static readonly Dictionary<char, char> MatchingChars = new()
        {
            { '}', '{' },
            { ']', '[' },
            { ')', '(' }
        };

        [TestCase("()", ExpectedResult = true)]
        [TestCase("()[]{}", ExpectedResult = true)]
        [TestCase("(]", ExpectedResult = false)]
        [TestCase("([])", ExpectedResult = true)]
        [TestCase("", ExpectedResult = true)] // Edge case: empty string
        [TestCase("(((((", ExpectedResult = false)] // Edge case: unbalanced
        [TestCase("{[()()]}", ExpectedResult = true)] // Nested valid
        [TestCase("{{[[(())]]}}", ExpectedResult = true)] // Deeply nested valid
        [TestCase("{[(])}", ExpectedResult = false)] // Invalid nesting
        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;
            if (s.Length % 2 == 1) return false;

            var stack = new Stack<char>();

            foreach (var c in s)
            {
                if (MatchingChars.ContainsValue(c)) 
                {
                    stack.Push(c);
                }
                else if (MatchingChars.TryGetValue(c, out var c1))
                {
                    if (stack.Count == 0 || stack.Peek() != c1)
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
    }
}
