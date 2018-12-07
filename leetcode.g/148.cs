using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.g
{
    [TestClass]
    public class _148
    {
        [TestMethod]
        public void SortListTest()
        {
            var h = new ListNode(4);
            h.next = new ListNode(1);
            var result = SortList(h);
        }

        public ListNode SortList(ListNode head)
        {
            var cur = head;
            var count = 0;
            while (cur != null)
            {
                count++;
                cur = cur.next;
            }

            if (count < 2) return head;
            var tmpNode = new TreeNode(0);
            return MergeSortList(head, count);
        }

        ListNode MergeSortList(ListNode head, int count)
        {
            if (count == 1)
            {
                head.next = null;
                return head;
            }

            int mid = count / 2;
            var head2 = head;
            for (int i = 0; i < mid; i++) head2 = head2.next;

            head = MergeSortList(head, mid);
            head2 = MergeSortList(head2, count - mid);

            var res = new ListNode(0);
            var cur = res;
            var cur1 = head;
            var cur2 = head2;
            for(int i = 0; i < count; i++)
            {
                if (cur2 == null || (cur1 != null && cur1.val <= cur2.val))
                {
                    cur.next = cur1;
                    cur1 = cur1.next;
                }
                else
                {
                    cur.next = cur2;
                    cur2 = cur2.next;
                }
                cur = cur.next;
            }
            cur.next = null;

            return res.next;
        }
    }
}
