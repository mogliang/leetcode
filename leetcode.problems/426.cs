using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace leetcode.problems
{
    [TestClass]
    public class _426
    {
        [TestMethod]
        public void MinMoves2Test()
        {
            Assert.AreEqual(2, MinMoves2(new [] {1,2,3 }));
        }

        public int MinMoves2(int[] nums)
        {
            var list = nums.ToList();
            list.Sort();
            var mid = list[list.Count / 2];
            var ret = 0;
            list.ForEach(n => ret += Math.Abs(n-mid));
            return ret;
        }
    }
}
