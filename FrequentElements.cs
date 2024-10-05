//https://leetcode.com/problems/top-k-frequent-elements/`

using NUnit.Framework;

namespace LeetCode
{
    [TestFixture]
    public class FrequentElements
    {
        [TestCase(new[] { 1, 1, 1, 2, 2, 3 }, 2, ExpectedResult = new[] { 1, 2 })]
        [TestCase(new[] { 1 }, 1, ExpectedResult = new[] { 1 })]
        [TestCase(new[] { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 }, 3, ExpectedResult = new[] { 4, 3, 2 })]
        [TestCase(new[] { 4, 4, 4, 4, 2, 2, 2, 1, 1, 1, 3 }, 2, ExpectedResult = new[] { 4, 2 })]
        public int[] TopKFrequent(int[] nums, int k)
        {
            var counterDict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!counterDict.ContainsKey(nums[i]))
                {
                    counterDict[nums[i]] = 0;
                }
                counterDict[nums[i]]++;
            }

            var counterList = new List<int>[nums.Length + 1];
            foreach (var count in counterDict)
            {
                counterList[count.Value] ??= [];
                counterList[count.Value].Add(count.Key);
            }
            
            var result = new List<int>();
            for (int i = counterList.Length - 1; i >= 0 ; i--)
            {
                if (counterList[i]?.Count > 0)
                {
                    var rangeLengthToAdd = Math.Min(k - result.Count, counterList[i].Count);
                    for (int j = 0; j < rangeLengthToAdd; j++)
                    {
                        result.Add(counterList[i][j]);
                    }
                }
                if(result.Count == k) break;
            }

            return result.ToArray();
        }
    }
}

