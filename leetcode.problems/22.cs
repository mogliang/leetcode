using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace leetcode.problems
{
    /// <summary>
    /// https://leetcode.com/problems/generate-parentheses/
    /// </summary>
    [TestClass]
    public class _22
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test = GenerateParenthesis(3);
        }

        // O(2^n)
        public IList<string> GenerateParenthesis(int n)
        {
            return GenerateParenthesisRec(0, n, "");
        }

        public IList<string> GenerateParenthesisRec(int stackDepth, int n, string result)
        {
            var ret = new List<string>();
            if (stackDepth > 0)
            {
                ret.AddRange(GenerateParenthesisRec(stackDepth - 1, n, result + ")"));
            }
            if (n > 0)
            {
                ret.AddRange(GenerateParenthesisRec(stackDepth + 1, n - 1, result + "("));
            }
            if(stackDepth==0 && n == 0)
            {
                ret.Add(result);
            }

            return ret;
        }

        // ²»ÕýÈ·
        //public IList<string> GenerateParenthesis2(int n)
        //{
        //    var ret = new List<string>();
        //    if (n == 0)
        //    {
        //        return ret;
        //    }
        //    else if (n == 1)
        //    {
        //        ret.Add("()");
        //    }
        //    else
        //    {
        //        var list = GenerateParenthesis(n - 1);
        //        foreach (var item in list)
        //        {
        //            var left = "()" + item;
        //            ret.Add(left);
        //            var right = item + "()";
        //            if (right != left)
        //                ret.Add(right);
        //            ret.Add($"({item})");
        //        }
        //    }

        //    return ret;
        //}
    }
}
