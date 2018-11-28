using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.problems
{
    [TestClass]
    public class _15
    {
        [TestMethod]
        public void ThreeSumTest()
        {
            var result = ThreeSum(new[] { -1, 0, 1, 2, -1, -4 });
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            var list = nums.ToList();
            list.Sort();

            for (int i = 0; i < list.Count; i++)
            {
                if (i > 0 && list[i] == list[i - 1]) continue;
                int a = list[i];
                int left = i+1;
                int right = list.Count - 1;
                while (left<right)
                {
                    var sum = a + list[left] + list[right];
                    if (sum == 0)
                    {
                        result.Add(new[] { a, list[left], list[right] });
                        while (left < right && list[left] == list[left + 1]) left++; left++;
                        while (right > left && list[right] == list[right - 1]) right--; right--;
                    }
                    else if (sum > 0) right--;
                    else left++;
                }
            }

            return result;
        }
    }
}
