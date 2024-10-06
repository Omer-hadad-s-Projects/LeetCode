//https://leetcode.com/problems/min-stack/description/

namespace LeetCode
{
    public class MinStack
    {
        private Stack<int> _values;
        private Stack<int> _minimumStack;
        
        public MinStack()
        {
            _values = new Stack<int>();
            _minimumStack = new Stack<int>();
        }

        public void Push(int val)
        {
            if (_minimumStack.Count == 0 || _minimumStack.Peek() >= val)
            {
                _minimumStack.Push(val);
            }
            _values.Push(val);
        }

        public void Pop()
        {
            var value =_values.Pop();
            if (_minimumStack.Peek() == value)
            {
                _minimumStack.Pop();
            }
        }

        public int Top()
        {
            return _values.Peek();
        }

        public int GetMin()
        {
            return _minimumStack.Peek();
        }
    }
}