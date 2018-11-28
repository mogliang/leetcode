using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace leetcode.problems
{
    [TestClass]
    public class _375
    {
        [TestMethod]
        public void GetMoneyAmountTest()
        {
            var result = GetMoneyAmount(7);
        }

        public int GetMoneyAmount(int n)
        {
            int[,] cache = new int[n, n];
            return GetMoneyAmountImpl(1, n, cache);
        }

        public int GetMoneyAmountImpl(int start, int end, int[,] cache)
        {
            if (start >= end)
            {
                return 0;
            }
            else if (end - start <= 2)
            {
                return (end + start) / 2;
            }
            else
            {
                if (cache[start - 1, end - 1] != 0) return cache[start - 1, end - 1];
                int min = int.MaxValue;
                for(int i=start; i<=end;i++)
                {
                    var val = Math.Max(GetMoneyAmountImpl(start, i - 1, cache), GetMoneyAmountImpl(i + 1, end, cache)) + i ;
                    if (val < min) min = val;
                }
                cache[start - 1, end - 1] = min;
                return min;
            }
        }
    }
}
