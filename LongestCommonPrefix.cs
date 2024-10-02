//https://leetcode.com/problems/longest-common-prefix
using NUnit.Framework;

namespace LeetCode
{
    [TestFixture]
    public class LongestCommonPrefix
    {
        [TestCase("flower", "flow", "flight", ExpectedResult = "fl")]
        [TestCase("dog", "racecar", "car", ExpectedResult = "")]
        [TestCase("a", ExpectedResult = "a")]
        [TestCase("", "b", ExpectedResult = "")]
        [TestCase("abc", "abc", "abc", ExpectedResult = "abc")]
        [TestCase("ab", "abc", "abcd", ExpectedResult = "ab")]
        [TestCase("abc", "ab", "a", ExpectedResult = "a")]
        [TestCase("flower", "flood", "flight", ExpectedResult = "fl")]
        public string Solution(params string[] strs)
        {
            if (strs.Length == 0) return "";
            var firstString = strs[0];

            int i;
            for (i = 0; i < firstString.Length; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length || firstString[i] != strs[j][i])
                    {
                        return firstString.Substring(0, i);
                    }
                }
            }

            return firstString;
        }
    }
}
