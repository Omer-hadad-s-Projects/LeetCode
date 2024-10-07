//https://leetcode.com/problems/evaluate-reverse-polish-notation/description/

using NUnit.Framework;

namespace LeetCode
{
    public class EvaluateReversePolishNotation
    {
        private readonly Dictionary<string, Func<int, int, int>> _functions = new()
        {
            { "+", Addition},
            { "-", Subtraction},
            { "*", Multiply},
            { "/", Divide}
        };
        
        private static int Addition(int num1, int num2)
        {
            return num1 + num2;
        }
        private static int Subtraction(int num1, int num2)
        {
            return num1 - num2;
        }
        private static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }
        
        
        private static int Divide(int num1, int num2)
        {
            return num1 / num2;
        }
        
        public int EvalRPN(string[] tokens)
        {
            var numbersStack = new Stack<int>();
            for (int i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                if (_functions.TryGetValue(token, out var func))
                {
                    var num2 = numbersStack.Pop();
                    var num1 = numbersStack.Pop();
                    var result = func(num1, num2);
                    numbersStack.Push(result);
                }
                else
                {
                    numbersStack.Push(int.Parse(token));
                }
            }

            return numbersStack.Pop();
        }
        
        
        [Test]
        public void TestExample1()
        {
            var tokens = new string[] { "2", "1", "+", "3", "*" };
            var result = EvalRPN(tokens);
            Assert.AreEqual(9, result);
        }

        [Test]
        public void TestExample2()
        {
            var tokens = new string[] { "4", "13", "5", "/", "+" };
            var result = EvalRPN(tokens);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void TestExample3()
        {
            var tokens = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            var result = EvalRPN(tokens);
            Assert.AreEqual(22, result);
        }
        
        [Test]
        public void TestSingleNumber()
        {
            var tokens = new string[] { "5" };
            var result = EvalRPN(tokens);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void TestNegativeResult()
        {
            var tokens = new string[] { "2", "3", "-" };
            var result = EvalRPN(tokens);
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void TestMultipleOperations()
        {
            var tokens = new string[] { "3", "4", "+", "2", "*", "7", "/" };
            var result = EvalRPN(tokens);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void TestComplexExpression()
        {
            var tokens = new string[] { "5", "1", "2", "+", "4", "*", "+", "3", "-" };
            var result = EvalRPN(tokens);
            Assert.AreEqual(14, result);
        }

        [Test]
        public void TestDivisionResultingInZero()
        {
            var tokens = new string[] { "3", "5", "/", "4", "*", "0", "+" };
            var result = EvalRPN(tokens);
            Assert.AreEqual(0, result);
        }

        
    }
    
}

