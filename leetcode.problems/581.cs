using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace leetcode.problems
{
    [TestClass]
    public class _581
    {
        [TestMethod]
        public void FindUnsortedSubarrayTest()
        {
            Assert.AreEqual(5, FindUnsortedSubarray(new[] { 2, 6, 4, 8, 10, 9, 15 }));
            Assert.AreEqual(0, FindUnsortedSubarray(new[] { 2, 4, 6, 8, 10 }));
            Assert.AreEqual(3, FindUnsortedSubarray(new[] { 3, 2, 2, 8, 10 }));
        }

        // O(N)
        public int FindUnsortedSubarray(int[] nums)
        {
            if (nums.Length < 2) return 0;

            int start = 0;
            while (start < nums.Length - 1 && nums[start] <= nums[start + 1]) start++;
            if (start == nums.Length - 1) return 0;

            int end = nums.Length - 1;
            while (end > 0 && nums[end] >= nums[end - 1]) end--;

            int min = int.MaxValue;
            for (int i = start; i <= end; i++)
                if (min > nums[i]) min = nums[i];

            int max = int.MinValue;
            for (int i = start; i <= end; i++)
                if (max < nums[i]) max = nums[i];

            while (start > 0 && nums[start - 1] > min) start--;
            while (end < nums.Length - 1 && nums[end + 1] < max) end++;
            return end - start + 1;
        }

        // O(NLogN)
        public int FindUnsortedSubarray_ONLogN(int[] nums)
        {
            var nums2 = nums.ToList();
            nums2.Sort();
            int start = nums.Length - 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != nums2[i])
                {
                    start = i;
                    break;
                }
            }
            if (start == nums.Length - 1) return 0;

            int end = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] != nums2[i])
                {
                    end = i;
                    break;
                }
            }
            return end - start + 1;
        }


        // O(N^2)
        public int FindUnsortedSubarray_ON2(int[] nums)
        {
            if (nums.Length < 2) return 0;
            int start = nums.Length - 1;
            for (int i = 0; i < nums.Length; i++)
            {
                int min = int.MaxValue;
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[j] < min)
                    {
                        min = nums[j];
                    }
                }
                if (min != nums[i])
                {
                    start = i;
                    break;
                }
            }

            if (start == nums.Length - 1) return 0;

            int end = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int max = int.MinValue;
                for (int j = i; j >= 0; j--)
                {
                    if (nums[j] > max)
                    {
                        max = nums[j];
                    }
                }
                if (max != nums[i])
                {
                    end = i;
                    break;
                }
            }

            return end - start + 1;
        }
    }
}
