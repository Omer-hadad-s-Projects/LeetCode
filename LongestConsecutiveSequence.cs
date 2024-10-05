//https://leetcode.com/problems/longest-consecutive-sequence/description/

using NUnit.Framework;

namespace LeetCode
{
    public class LongestConsecutiveSequence
    {
        private int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) return 0;
            
            var set = GetHashSet(nums);

            var maximumConsecutive = 1;
            foreach (var value in set)
            {
                var valueConsectutive = 1 + SearchUp(ref set, value) + SearchDown(ref set, value);
                set.Remove(value);
                maximumConsecutive = Math.Max(valueConsectutive, maximumConsecutive);
            }

            return maximumConsecutive;
        }
        
        private HashSet<int> GetHashSet(int[] nums)
        {
            var set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
            }

            return set;
        }

        private int SearchUp(ref HashSet<int> set, int value)
        {
            var counter = 0;
            while (set.Contains(value + 1))
            {
                value++;
                counter++;
                set.Remove(value);
            }

            return counter;
        }

        private int SearchDown(ref HashSet<int> set, int value)
        {
            var counter = 0;
            while (set.Contains(value - 1))
            {
                value--;
                counter++;
                set.Remove(value);
            }

            return counter;
        }

        [Test]
        public void LongestConsecutive_Test1()
        {
            int[] nums = { 100, 4, 200, 1, 3, 2 };
            Assert.AreEqual(4, LongestConsecutive(nums));
        }

        [Test]
        public void LongestConsecutive_Test2()
        {
            int[] nums = { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
            Assert.AreEqual(9, LongestConsecutive(nums));
        }

        [Test]
        public void LongestConsecutive_Test3()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            Assert.AreEqual(5, LongestConsecutive(nums));
        }

        [Test]
        public void LongestConsecutive_Test4()
        {
            int[] nums = { 10, 1, 2, 3, 4, 20 };
            Assert.AreEqual(4, LongestConsecutive(nums));
        }

        [Test]
        public void LongestConsecutive_Test5()
        {
            int[] nums = { 100, 200, 300, 400, 500 };
            Assert.AreEqual(1, LongestConsecutive(nums));
        }

        [Test]
        public void LongestConsecutive_Test6()
        {
            int[] nums = { 1, 2, 2, 3, 4, 5, 6 };
            Assert.AreEqual(6, LongestConsecutive(nums));
        }

        [Test]
        public void LongestConsecutive_Test7()
        {
            int[] nums = { 7, 8, 9, 1, 2, 3, 4, 5, 6 };
            Assert.AreEqual(9, LongestConsecutive(nums));
        }

        [Test]
        public void LongestConsecutive_Test8()
        {
            int[] nums = { -1, -2, -3, -4, -5 };
            Assert.AreEqual(5, LongestConsecutive(nums));
        }
        
        [Test]
        public void LongestConsecutive_Test9()
        {
            int[] nums = {};
            Assert.AreEqual(0, LongestConsecutive(nums));
        }
    }
}