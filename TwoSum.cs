using NUnit.Framework;

namespace LeetCode
{
    [TestFixture]
    public class TwoSum
    {
        public int[] TwoSumSolution(int[] nums, int target)
        {
            var set = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var difference = target - nums[i];
                if (set.TryGetValue(difference, out var value))
                {
                    return [value, i];
                }

                set[nums[i]] = i;
            }

            return [];
        }

        [TestCase(new[] { 2, 7, 11, 15 }, 9, ExpectedResult = new int[] { 0, 1 })]
        [TestCase(new[] { 3, 2, 4 }, 6, ExpectedResult = new int[] { 1, 2 })]
        [TestCase(new[] { 3, 3 }, 6, ExpectedResult = new int[] { 0, 1 })]
        [TestCase(new[] { 1, 5, 3, 8 }, 9, ExpectedResult = new int[] { 0, 3 })]
        [TestCase(new[] { 1, 1, 1, 2 }, 3, ExpectedResult = new int[] { 2, 3 })]
        [TestCase(new[] { 4, 6 }, 10, ExpectedResult = new int[] { 0, 1 })]
        [TestCase(new[] { 1, 7, 11, 2 }, 9, ExpectedResult = new int[] { 1, 3 })]
        [TestCase(new[] { 5, 5 }, 10, ExpectedResult = new int[] { 0, 1 })]
        public int[] TwoSumSolution_WithVariousInputs_ReturnsExpectedResult(int[] nums, int target)
        {
            return TwoSumSolution(nums, target);
        }
    }
}

