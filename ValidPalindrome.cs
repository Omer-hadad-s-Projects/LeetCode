//https://leetcode.com/problems/valid-palindrome/description/

using System.Text.RegularExpressions;
using NUnit.Framework;

namespace LeetCode
{
    public class ValidPalindrome
    {
        [TestCase("A man, a plan, a canal: Panama", ExpectedResult = true)]
        [TestCase("race a car", ExpectedResult = false)]
        [TestCase(" ", ExpectedResult = true)]
        [TestCase("0P", ExpectedResult = false)]
        public bool IsPalindrome(string s)
        {
            s = FormatString(s);

            var i = 0;
            var j = s.Length - 1;
            while (j > i)
            {
                if (s[i] != s[j]) return false;
                i++;
                j--;
            }

            return true;
        }

        private string FormatString(string str)
        {
            return Regex.Replace(str.ToLower(), "[^a-z0-9]", "");
        }
    }
}

