using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.problems
{
    [TestClass]
    public class _324
    {
        [TestMethod]
        public void IncreasingTripletTest()
        {
            Assert.IsTrue(IncreasingTriplet(new int[] { 5, 1, 5, 5, 2, 5, 4 }));
        }

        public bool IncreasingTriplet(int[] nums)
        {
            if (nums.Length < 3)
                return false;

            int min = nums[0];
            int[] arr = new[] { nums[0], int.MaxValue };
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > arr[1])
                {
                    return true;
                }
                else if (nums[i] > arr[0])
                {
                    arr[1] = nums[i];
                }
                else if (nums[i] > min)
                {
                    arr[0] = min;
                    arr[1] = nums[i];
                }
                else
                {
                    min = nums[i];
                }
            }
            return false;
        }
    }
}
