//https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/submissions/1417376446/

using NUnit.Framework;

namespace LeetCode
{
    public class Two2InputArrayIsSorted
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var i = 0;
            var j = numbers.Length - 1;
            while (true)
            {
                var sum = numbers[i] + numbers[j];
                if (sum == target)
                {
                    return [i + 1, j + 1];
                }

                if (sum > target)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return [];
        }
    
        [Test]
        public void TestExample1()
        {
            int[] numbers = { 2, 7, 11, 15 };
            int target = 9;
            int[] result = TwoSum(numbers, target);
            Assert.AreEqual(new int[] { 1, 2 }, result);
        }

        [Test]
        public void TestExample2()
        {
            int[] numbers = { 2, 3, 4 };
            int target = 6;
            int[] result = TwoSum(numbers, target);
            Assert.AreEqual(new int[] { 1, 3 }, result);
        }

        [Test]
        public void TestExample3()
        {
            int[] numbers = { -1, 0 };
            int target = -1;
            int[] result = TwoSum(numbers, target);
            Assert.AreEqual(new int[] { 1, 2 }, result);
        }
    }
}

