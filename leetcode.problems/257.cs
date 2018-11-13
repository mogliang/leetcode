using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace leetcode.problems
{
    [TestClass]
    public class _257
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var list = new List<string>();
            BinaryTreePaths(root, string.Empty, list);
            return list;
        }

        public void BinaryTreePaths(TreeNode node, string prefix, IList<string> list)
        {
            if (node == null)
            {
                return;
            }
            var path = prefix == string.Empty ? node.val.ToString() : prefix + "->" + node.val;
            if (node.left != null)
            {
                BinaryTreePaths(node.left, path, list);
            }
            if (node.right != null)
            {
                BinaryTreePaths(node.right, path, list);
            }
            if (node.left == null && node.right == null)
            {
                list.Add(path);
            }
        }
    }
}
