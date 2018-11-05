using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.problems
{
    /// <summary>
    /// https://leetcode.com/problems/counting-bits/
    /// </summary>
    [TestClass]
    public class _338
    {
        [TestMethod]
        public void CountBitsTest()
        {
            var result = CountBits(2);
        }

        public int[] CountBits(int num)
        {
            num += 1;
            if (num == 1)
            {
                return new int[] { 0 };
            }

            var ret = new int[num];
            ret[0] = 0;
            ret[1] = 1;

            int window = 1;
            int windowPos = 2;
            for (int i = 2; i < num; i++)
            {
                if (i - windowPos == window * 2)
                {
                    window *= 2;
                    windowPos = i;
                }

                if (i - windowPos < window)
                {
                    ret[i] = ret[windowPos - window + i - windowPos];
                }
                else if (i - windowPos < 2 * window)
                {
                    ret[i] = ret[windowPos - window + i - windowPos] + 1;
                }
            }

            return ret;
        }
    }
}
