//https://leetcode.com/problems/daily-temperatures/description/

using NUnit.Framework;

namespace LeetCode
{
    public class DailyTemperatures
    {
        public int[] Solution(int[] temperatures)
        {
            var stack = new Stack<(int, int)>();
            var result = new int[temperatures.Length];
            for (int i = temperatures.Length - 1; i >= 0; i--)
            {
                var temperature = temperatures[i];
                while (stack.Count > 0 && temperature >= stack.Peek().Item1)
                {
                    stack.Pop();
                }
                
                if (stack.Count == 0)
                {
                    stack.Push((temperature, i));
                    result[i] = 0;
                    continue;
                }

                if (temperature < stack.Peek().Item1)
                {
                    result[i] = stack.Peek().Item2 - i;
                    stack.Push((temperature, i));
                }
            }

            return result;
        }

        [Test]
        public void Test1()
        {
            var input = new int[] { 89, 62, 70, 58, 47, 47, 46, 76, 100, 70 };
            var result = Solution(input);
            var expected = new int[] { 8, 1, 5, 4, 3, 2, 1, 1, 0, 0 };
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Test2()
        {
            var input = new int[] { 73, 74, 75, 71, 69, 72, 76, 73 };
            var result = Solution(input);
            var expected = new int[] { 1, 1, 4, 2, 1, 1, 0, 0 };
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Test3()
        {
            var input = new int[] { 30, 40, 50, 60 };
            var result = Solution(input);
            var expected = new int[] { 1, 1, 1, 0 };
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Test4()
        {
            var input = new int[] { 30, 60, 90 };
            var result = Solution(input);
            var expected = new int[] { 1, 1, 0 };
            Assert.AreEqual(result, expected);
        }
    }
}


