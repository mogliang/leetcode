using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace leetcode.problems
{
    /// <summary>
    /// https://leetcode.com/problems/summary-ranges/
    /// </summary>
    [TestClass]
    public class _228
    {
        [TestMethod]
        public void SummaryRangesTest()
        {
            SummaryRanges(new[] { 0, 1, 2, 4, 5, 7 });
        }

        public IList<string> SummaryRanges(int[] nums)
        {
            if (nums.Length == 0)
            {
                return new List<string>();
            }
            if (nums.Length == 1)
            {
                return new List<string> { nums[0].ToString() };
            }

            var ret = new List<string>();
            int startPos = 0;
            int start = nums[0];
            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] != 1)
                {
                    if (startPos == i - 1)
                        ret.Add(start.ToString());
                    else
                    {
                        ret.Add($"{start}->{nums[i - 1]}");
                    }
                    startPos = i;
                    start = nums[i];
                }
            }

            if (startPos == nums.Length - 1)
            {
                ret.Add(start.ToString());
            }
            else
            {
                ret.Add($"{start}->{nums[nums.Length - 1]}");
            }

            return ret;
        }
    }
}
