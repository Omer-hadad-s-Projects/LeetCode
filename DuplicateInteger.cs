//https://leetcode.com/problems/contains-duplicate/

using NUnit.Framework;

namespace LeetCode
{
    [TestFixture]
    public class DuplicateInteger
    {
        [TestCase(new int[] { 1, 2, 3, 1 }, ExpectedResult = true)]
        [TestCase(new int[] { 1, 2, 3, 4 }, ExpectedResult = false)]
        [TestCase(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, ExpectedResult = true)]
        [TestCase(new int[] { 5, 6, 7, 8, 9 }, ExpectedResult = false)] 
        [TestCase(new int[] { 9, 9 }, ExpectedResult = true)] 
        [TestCase(new int[] { 100 }, ExpectedResult = false)] 
        [TestCase(new int[] { }, ExpectedResult = false)] 
        public bool ContainsDuplicate(int[] nums)
        {
            var hashSet = new HashSet<int>();
            foreach (var num in nums)
            {
                if (!hashSet.Add(num)) return true;
            }
            return false;
        }
    }
}

