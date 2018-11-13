using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.problems
{
    [TestClass]
    public class _744
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        public char NextGreatestLetter(char[] letters, char target)
        {
            char min = '{';
            char min2 = '{';
            foreach (var c in letters)
            {
                if (c > target && c < min) min = c;
                else if (c < min2) min2 = c;
            }
            return min == '{' ? min2 : min;
        }
    }
}
