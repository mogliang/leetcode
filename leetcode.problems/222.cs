using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace leetcode.problems
{
    [TestClass]
    public class _222
    {
        [TestMethod]
        public void CountNodesTest()
        {
            var root = new TreeNode(0);
            root.left = new TreeNode(0);
            var count = CountNodes(root);
        }

        public int CountNodes(TreeNode root)
        {
            if (root == null) return 0;
            var depth = MeasureDepth(root, true);
            var rightDepath = MeasureDepth(root.right, true);
            if (depth == rightDepath + 1)
            {
                return (1 << (depth - 1)) + CountNodes(root.right);
            }
            else
            {
                return (1 << (depth - 2)) + CountNodes(root.left);
            }
        }

        int MeasureDepth(TreeNode root, bool left)
        {
            if (root == null) return 0;
            var depth = 0;
            var cur = root;
            while (true)
            {
                if (root != null)
                {
                    root = left ? root.left : root.right;
                    depth++;
                }
                else
                {
                    break;
                }
            }
            return depth;
        }

        // count nodes
        //public int CountNodes(TreeNode root)
        //{
        //    if (root == null) return 0;
        //    var depth = MeasureDepth(root, true);
        //    return CountNodesImpl(root, depth);
        //}

        //int CountNodesImpl(TreeNode root, int depth)
        //{
        //    if (root == null) return 0;
        //    else if (MeasureDepth(root, false) == depth) return (int)Math.Pow(2, depth) - 1;
        //    else return 1 + CountNodesImpl(root.left, depth - 1) + CountNodesImpl(root.right, depth - 1);
        //}
    }
}
