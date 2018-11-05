using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.problems
{
    /// <summary>
    /// https://leetcode.com/problems/predict-the-winner/
    /// </summary>
    [TestClass]
    public class _486
    {
        [TestMethod]
        public void PredictTheWinnerTest()
        {
            Assert.AreEqual(false, PredictTheWinner(new[] { 1, 5, 2 }));
            Assert.AreEqual(true, PredictTheWinner(new[] { 1, 5, 233, 7 }));
        }

        public bool PredictTheWinner(int[] nums)
        {
            if (nums.Length == 1)
                return true;

            int a, b;
            Predict(nums, 0, nums.Length - 1, true, out a, out b);
            return a >= b;
        }

        void Predict(int[] nums, int start, int end, bool aturn, out int a, out int b)
        {
            if (end - start == 1)
            {
                var max = Math.Max(nums[start], nums[end]);
                var min =Math.Min(nums[start], nums[end]);
                if (aturn)
                {
                    a = max;
                    b = min;
                }
                else
                {
                    a = min;
                    b = max;
                }
            }
            else
            {
                int ta, tb;
                Predict(nums, start + 1, end, !aturn, out ta, out tb);

                int ta2, tb2;
                Predict(nums, start, end - 1, !aturn, out ta2, out tb2);

                if (aturn)
                {
                    ta += nums[start];
                    ta2 += nums[end];
                    if (ta > ta2)
                    {
                        a = ta;
                        b = tb;
                        return;
                    }
                    else
                    {
                        a = ta2;
                        b = tb2;
                        return;
                    }
                }
                else
                {
                    tb += nums[start];
                    tb2 += nums[end];
                    if (tb > tb2)
                    {
                        a = ta;
                        b = tb;
                        return;
                    }
                    else
                    {
                        a = ta2;
                        b = tb2;
                        return;
                    }
                }
            }
        }
    }
}
