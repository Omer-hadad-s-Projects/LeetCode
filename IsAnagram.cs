//https://leetcode.com/problems/valid-anagram/

using NUnit.Framework;

namespace LeetCode
{
    [TestFixture]
    public class IsAnagram
    {
        [TestCase("anagram", "nagaram", ExpectedResult = true)]
        [TestCase("rat", "car", ExpectedResult = false)]
        [TestCase("listen", "silent", ExpectedResult = true)]
        [TestCase("hello", "bello", ExpectedResult = false)]
        [TestCase("a", "a", ExpectedResult = true)]
        [TestCase("ab", "ba", ExpectedResult = true)]
        [TestCase("abcd", "abc", ExpectedResult = false)]
        [TestCase("", "", ExpectedResult = true)]
        [TestCase("aabbcc", "abcabc", ExpectedResult = true)]
        [TestCase("aaabbb", "ababab", ExpectedResult = true)]
        public bool IsAnagramSolution(string s, string t)
        {
            var valuesOccurence = GetValuesDict(s);
            for (int i = 0; i < t.Length; i++)
            {
                var key = t[i];
                if (!valuesOccurence.ContainsKey(key)) return false;
                switch (valuesOccurence[key])
                {
                    case > 1:
                        valuesOccurence[key]--;
                        break;
                    case 1:
                        valuesOccurence.Remove(key);
                        break;
                }
            }

            return valuesOccurence.Count == 0;
        }

        private static Dictionary<char, int> GetValuesDict(string s)
        {
            var valuesOccurence = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                var value = s[i];
                if (!valuesOccurence.TryAdd(value, 1))
                {
                    valuesOccurence[value]++;
                }
            }

            return valuesOccurence;
        }
    }
}