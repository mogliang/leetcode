using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.problems
{
    [TestClass]
    public class _450
    {
        [TestMethod]
        public void DeleteNodeTest()
        {
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            var newRoot = DeleteNode(root, 1);
        }

        public TreeNode DeleteNode(TreeNode root, int key)
        {
            bool left = true;
            var newRoot = new TreeNode(int.MinValue);
            newRoot.left = root;
            TreeNode parent = newRoot;
            var cur = root;
            while (cur != null)
            {
                if (cur.val == key)
                {
                    DeleteNode(parent, cur, left);
                    break;
                }
                else if(cur.val> key)
                {
                    parent = cur;
                    cur = cur.left;
                    left = true;
                }
                else
                {
                    parent = cur;
                    cur = cur.right;
                    left = false;
                }
            }

            return newRoot.left;
        }

        // 寻找左树最右节点newNode
        // 最右节点parent.right=newNode.left
        // 把删除节点的左右树付给newNode
        // 把删除节点的parent连接newNode
        void DeleteNode(TreeNode parent, TreeNode delNode, bool left)
        {
            var newNode = delNode.left;
            if (newNode == null)
            {
                if (left)
                {
                    parent.left = delNode.right;
                }
                else
                {
                    parent.right = delNode.right;
                }
            }
            else
            {
                TreeNode newNodeParent = null;
                while (newNode.right != null)
                {
                    newNodeParent = newNode;
                    newNode = newNode.right;
                }
                if (newNodeParent != null)
                    newNodeParent.right = newNode.left;

                newNode.right = delNode.right;
                if (delNode.left != newNode) newNode.left = delNode.left;

                if (left)
                {
                    parent.left = newNode;
                }
                else
                {
                    parent.right = newNode;
                }
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
