using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.problems
{
    [TestClass]
    public class _623
    {
        [TestMethod]
        public void AddOneRowTest()
        {
        }

        public TreeNode AddOneRow(TreeNode root, int v, int d)
        {
            if (root == null)
            {
                return null;
            }
            else if (d == 1)
            {
                var newRoot = new TreeNode(v);
                newRoot.left = root;
                return newRoot;
            }
            else if (d == 2)
            {
                var left = new TreeNode(v);
                left.left = root.left;
                root.left = left;

                var right = new TreeNode(v);
                right.right = root.right;
                root.right = right;
                return root;
            }
            else
            {
                AddOneRow(root.left, v, d - 1);
                AddOneRow(root.right, v, d - 1);
                return root;
            }
        }
    }
}
