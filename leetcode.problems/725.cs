using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.problems
{
    [TestClass]
    public class _725
    {
        [TestMethod]
        public void SplitListToPartsTest()
        {
            var root = new ListNode(1);
            var node = root;
            //node.next = new ListNode(2); node = node.next;
            //node.next = new ListNode(3); node = node.next;
            //node.next = new ListNode(4); node = node.next;
            //node.next = new ListNode(5); node = node.next;
            //node.next = new ListNode(6); node = node.next;
            //node.next = new ListNode(7); node = node.next;

            var list = SplitListToParts(root, 3);
        }

        public ListNode[] SplitListToParts(ListNode root, int k)
        {
            var ret = new ListNode[k];
            if (root == null || k == 0)
            {
                return ret;
            }

            // count
            var count = 0;
            var cur = root;
            while (cur != null)
            {
                count++;
                cur = cur.next;
            }

            int subCount = count / k;
            int remain = count % k;
            int idx = 0;
            cur = root;
            int nidx = 0;
            for (int i = 0; i < count; i++)
            {
                if (idx == 0)
                {
                    ret[nidx] = cur;
                }

                if (idx == subCount + (remain > 0 ? 1 : 0) - 1)
                {
                    idx = 0;
                    nidx++;
                    remain--;
                    var temp = cur;
                    cur = cur.next;
                    temp.next = null;
                }
                else
                {
                    cur = cur.next;
                    idx++;
                }
            }

            return ret;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
