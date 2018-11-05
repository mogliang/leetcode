using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.problems
{
    /// <summary>
    /// https://leetcode.com/problems/unique-substrings-in-wraparound-string/
    /// </summary>
    [TestClass]
    public class _150
    {
        [TestMethod]
        public void EvalRPNTest()
        {
            Assert.AreEqual(9, EvalRPN(new[] { "2", "1", "+", "3", "*" }));
            Assert.AreEqual(0, EvalRPN(new[] { "0", "3", "/" }));
        }

        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (isOperator(tokens[i]))
                {
                    stack.Push(calculate(stack.Pop(), stack.Pop(), tokens[i]));
                }else
                {
                    stack.Push(int.Parse(tokens[i]));
                }
            }
            return stack.Pop();
        }

        bool isOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }

        int calculate(int a, int b, string op)
        {
            switch (op)
            {
                case "+":
                    return b + a;
                case "-":
                    return b - a;
                case "*":
                    return b * a;
                case "/":
                    return b / a;
            }
            return -1;
        }
    }
}
