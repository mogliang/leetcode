using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.problems
{
    [TestClass]
    public class _297
    {
        [TestMethod]
        public void serializeTest()
        {
            var root = new TreeNode(0);
            //root.left = new TreeNode(2);
            //root.right = new TreeNode(4);
            //root.left.left = new TreeNode(1);
            //root.right.right = new TreeNode(5);
            var node = root;
            for(int i = 1; i < 1000; i++)
            {
                node.right = new TreeNode(i);
                node = node.right;
            }

            var result = serialize(root);
            var root2 = deserialize(result);

            var result2 = serialize(null);
            var root3 = deserialize(result2);
        }

        const string nu = "NULL";
        const char seq = ',';
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) return string.Empty;
            var sb = new StringBuilder();
            se(root, sb);

            if (sb.Length > 0) sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        void se(TreeNode node, StringBuilder sb)
        {
            if (node != null)
            {
                sb.Append(node.val);
                sb.Append(seq);
                se(node.left, sb);
                se(node.right, sb);
            }
            else
            {
                sb.Append(nu);
                sb.Append(seq);
            }
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == string.Empty) return null;

            var list = data.Split(seq);
            idx = 0;
            return de(list);
        }

        int idx = 0;
        TreeNode de(string[] list)
        {
            if (idx >= list.Length) return null;

            var cur = list[idx];
            if (cur == nu) {
                idx++;
                return null;
            }

            var node = new TreeNode(int.Parse(cur));
            idx++;
            node.left = de(list);
            node.right = de(list);
            return node;
        }
    }
}
