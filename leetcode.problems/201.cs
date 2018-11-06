using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.problems
{
    /// <summary>
    /// https://leetcode.com/problems/bitwise-and-of-numbers-range/
    /// </summary>
    [TestClass]
    public class _201
    {
        [TestMethod]
        public void RangeBitwiseAndTest()
        {
            //Assert.AreEqual(4, RangeBitwiseAnd(5, 7));
            //Assert.AreEqual(0, RangeBitwiseAnd(0, 1));
            //Assert.AreEqual(2, RangeBitwiseAnd(2, 3));
            Assert.AreEqual(4, RangeBitwiseAnd(4, 5));
        }

        public int RangeBitwiseAnd(int m, int n)
        {
            if (m == n)
                return m;

            var ret = 0;
            var msb = Math.Max(Msb(m), Msb(n));
            var dis = n - m;
            for(int i = msb; i >= 0; i--)
            {
                if (dis >= (1 << i))
                {
                    ret *= 2;
                }
                else
                {
                    ret = ret * 2 + (Bit(m, i) && Bit(n, i) ? 1 : 0);
                }
            }

            return ret;
        }

        bool Bit(int num, int pos)
        {
            return (num & (1 << pos)) != 0;
        }

        int Msb(int num)
        {
            for(int i = 0; i < int.MaxValue; i++)
            {
                if ((1 << i) - num >= 0)
                    return i - 1;
            }
            return int.MaxValue;
        }
    }
}
