//https://leetcode.com/problems/palindrome-number/description/
using NUnit.Framework;

namespace LeetCode
{
    [TestFixture]
    public class PalindromNumberTests
    {
        [TestCase(121, ExpectedResult = true)]
        [TestCase(-121, ExpectedResult = false)]
        [TestCase(500, ExpectedResult = false)]
        [TestCase(2222, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = true)]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(12321, ExpectedResult = true)]
        [TestCase(1234321, ExpectedResult = true)]
        [TestCase(10, ExpectedResult = false)]

        public static bool IsPalindrom(int x)
        {
            if (x < 0) return false;
            var original = x;
            var copy = 0;
            while (copy < original && x > 0)
            {
                copy *= 10;
                var modulo = x % 10;
                copy += modulo;
                x = (x - modulo) / 10;
            }  
            return copy == original;
        }
    }
}