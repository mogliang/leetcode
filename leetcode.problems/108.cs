using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.problems
{
    [TestClass]
    public class _108
    {
        [TestMethod]
        public void SortedArrayToBSTTest()
        {
            var list = SortedArrayToBST(new[] { -10, -3, 0, 5, 9 });
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        public TreeNode SortedArrayToBST(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            else if (start == end)
            {
                return new TreeNode(nums[start]);
            }
            else
            {
                var mid = (start + end) / 2;
                var node = new TreeNode(nums[mid]);
                node.left = SortedArrayToBST(nums, start, mid - 1);
                node.right = SortedArrayToBST(nums, mid + 1, end);
                return node;
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
