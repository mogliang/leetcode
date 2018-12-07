using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.g
{
    public class _951
    {
        public bool FlipEquiv(TreeNode root1, TreeNode root2)
        {
            if(root1==null || root2 == null)
            {
                return root1 == null && root2 == null;
            }

            if (root1.val == root2.val)
            {
                return (FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right)) ||
                    (FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left));
            }
            else
            {
                return false;
            }
        }
    }
}
