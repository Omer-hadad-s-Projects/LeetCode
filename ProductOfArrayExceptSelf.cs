//https://leetcode.com/problems/product-of-array-except-self/description/

using NUnit.Framework;

namespace LeetCode
{
    public class ProductOfArrayExceptSelf
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var ascendingDict = new Dictionary<int, int>();
            var multiplactionValue = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                multiplactionValue *= nums[i];
                ascendingDict[i] = multiplactionValue;
            }

            var descendingDict = new Dictionary<int, int>();
            multiplactionValue = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                multiplactionValue *= nums[i];
                descendingDict[i] = multiplactionValue;
            }

            var result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                var valueBefore = ascendingDict.GetValueOrDefault(i - 1, 1);
                var valueAfter = descendingDict.GetValueOrDefault(i + 1, 1);
                result[i] = valueBefore * valueAfter;
            }

            return result;
        }

        [Test]
        public void ProductExceptSelf_Test1()
        {
            var input = new int[] { 1, 2, 3, 4 };
            var expected = new int[] { 24, 12, 8, 6 };

            var result = ProductExceptSelf(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProductExceptSelf_Test2()
        {
            var input = new int[] { -1, 1, 0, -3, 3 };
            var expected = new int[] { 0, 0, 9, 0, 0 };

            var result = ProductExceptSelf(input);

            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ProductExceptSelf_Test3()
        {
            var input = new int[] { 0, 0, 0, 0 };
            var expected = new int[] { 0, 0, 0, 0 };

            var result = ProductExceptSelf(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProductExceptSelf_Test4()
        {
            var input = new int[] { 1, 2, 0, 4 };
            var expected = new int[] { 0, 0, 8, 0 };

            var result = ProductExceptSelf(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProductExceptSelf_Test5()
        {
            var input = new int[] { 1, -1, 1, -1 };
            var expected = new int[] { 1, -1, 1, -1 };

            var result = ProductExceptSelf(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProductExceptSelf_Test6()
        {
            var input = new int[] { 2, 2, 2, 2 };
            var expected = new int[] { 8, 8, 8, 8 };

            var result = ProductExceptSelf(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ProductExceptSelf_Test7()
        {
            var input = new int[] { 5, 6, 7, 8 };
            var expected = new int[] { 336, 280, 240, 210 };

            var result = ProductExceptSelf(input);

            Assert.AreEqual(expected, result);
        }

    }
}