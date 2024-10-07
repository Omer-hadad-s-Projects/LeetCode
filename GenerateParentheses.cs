//https://leetcode.com/problems/generate-parentheses/description/

using NUnit.Framework;

namespace LeetCode
{
    public class GenerateParentheses
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var charList = new List<char>();
            var result = new List<string>();
            
            void backtrack(int openCount, int closedCount)
            {
                if (openCount == closedCount && closedCount == n) 
                {
                    result.Add(new string(charList.ToArray()));
                    return;
                }

                if (openCount < n)
                {
                    charList.Add('(');
                    backtrack(openCount + 1, closedCount);
                    charList.RemoveAt(charList.Count - 1);
                }
                
                if (openCount > closedCount)
                {
                    charList.Add(')');
                    backtrack(openCount, closedCount + 1);
                    charList.RemoveAt(charList.Count - 1);
                }
            }
            
            backtrack(0, 0);
            return result;
        }

        [Test]
        public void TestExample1()
        {
            var n = 3;
            var expected = new List<string> { "((()))", "(()())", "(())()", "()(())", "()()()" };
            var result = GenerateParenthesis(n);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestExample2()
        {
            var n = 1;
            var expected = new List<string> { "()" };
            var result = GenerateParenthesis(n);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestCustom1()
        {
            var n = 2;
            var expected = new List<string> { "(())", "()()" };
            var result = GenerateParenthesis(n);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestCustom2()
        {
            var n = 4;
            var expected = new List<string>
            {
                "(((())))", "((()()))", "((())())", "((()))()", "(()(()))",
                "(()()())", "(()())()", "(())(())", "(())()()", "()((()))",
                "()(()())", "()(())()", "()()(())", "()()()()"
            };
            var result = GenerateParenthesis(n);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestCustom3()
        {
            var n = 0;
            var expected = new List<string> { "" };
            var result = GenerateParenthesis(n);
            Assert.AreEqual(expected, result);
        }
    }
}
