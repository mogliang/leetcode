using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.problems
{
    [TestClass]
    public class _526
    {
        [TestMethod]
        public void CountArrangementTest()
        {
            Assert.AreEqual(36, CountArrangement(6));
        }

        public int CountArrangement(int N)
        {
            var nums = new int[N];
            for (int i = 0; i < nums.Length; i++) nums[i] = i + 1;
            var result = CountArrangementImpl(nums, 0);
            return result;
        }

        public int CountArrangementImpl(int[] nums, int start)
        {
            if (start < nums.Length - 1)
            {
                var count = 0;
                for(int i = start; i < nums.Length; i++)
                {
                    Swap(nums, start, i);
                    if(IsDivideable(nums,start))
                    {
                        count += CountArrangementImpl(nums, start + 1);
                    }
                    Swap(nums, start, i);
                }
                return count;
            }
            else
            {
                return IsDivideable(nums, start) ? 1 : 0;
            }
        }

        bool IsDivideable(int[] nums, int pos)
        {
            if ((pos + 1) % nums[pos] == 0 || nums[pos] % (pos + 1) == 0)
                return true;
            else
                return false;
        }

        void Swap(int[] nums, int left, int right)
        {
            if (left == right) return;
            var temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
        }
    }
}
