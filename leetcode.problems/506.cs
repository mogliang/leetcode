using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.problems
{
    [TestClass]
    public class _506
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = FindRelativeRanks(new int[] {5,4 });
        }

        public string[] FindRelativeRanks(int[] nums)
        {
            var idx = new int[nums.Length];
            for (int i = 0; i < idx.Length; i++) idx[i] = i;

            for(int i = 1; i < nums.Length; i++)
            {
                for(int j = i - 1; j >= 0; j--)
                {
                    if (nums[j + 1] > nums[j])
                    {
                        var tmp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = tmp;

                        tmp = idx[j];
                        idx[j] = idx[j + 1];
                        idx[j + 1] = tmp;
                    }
                }
            }

            var result = new string[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {
                result[idx[i]] = (i+1).ToString();
            }
            if(idx.Length>0)result[idx[0]] = "Gold Medal";
            if (idx.Length > 1) result[idx[1]] = "Silver Medal";
            if (idx.Length > 2) result[idx[2]] = "Bronze Medal";
            return result;
        }
    }
}
