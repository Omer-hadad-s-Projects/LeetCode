//https://leetcode.com/problems/valid-parentheses/
using NUnit.Framework;

namespace LeetCode
{
    [TestFixture]
    public class ValidParenthesesTests
    {
        private static Dictionary<char, char> MatchingChars = new Dictionary<char, char>()
        {
            { '{', '}' },
            { '[', ']' },
            { '(', ')' }
        };

        [TestCase("()", ExpectedResult = true)]
        [TestCase("()[]{}", ExpectedResult = true)]
        [TestCase("(]", ExpectedResult = false)]
        [TestCase("([])", ExpectedResult = true)]
        [TestCase("", ExpectedResult = true)] // Edge case: empty string
        [TestCase("(((((", ExpectedResult = false)] // Edge case: unbalanced
        //[TestCase("{[()()]}", ExpectedResult = true)] // Nested valid
        [TestCase("{{[[(())]]}}", ExpectedResult = true)] // Deeply nested valid
        [TestCase("{[(])}", ExpectedResult = false)] // Invalid nesting
        public bool IsValid(string s)
        {
            if (s.Length == 0) return true;
            if (s.Length % 2 == 1) return false;

            for (int i = s.Length - 1; i > 0; i--)
            {
                char firstChar = s[0];
                char matchingChar = MatchingChars[firstChar];

                if (s[i] != matchingChar) continue;

                var firstStr = s.Substring(1, i - 1);
                var secondStr = i + 1 >= s.Length ? "" : s.Substring(i + 1, s.Length - (i + 1));
                return IsValid(firstStr) && IsValid(secondStr);
            }

            return false;
        }
    }
}
