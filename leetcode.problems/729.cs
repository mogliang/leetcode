using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.problems
{
    [TestClass]
    public class _729
    {
        [TestMethod]
        public void BookTest()
        {
            var MyCalendar = new _729();
            Assert.IsTrue(MyCalendar.Book(10, 20)); // returns true
            Assert.IsFalse(MyCalendar.Book(15, 25)); // returns false
            Assert.IsTrue(MyCalendar.Book(20, 30)); // returns true
        }

        Node _root = new Node(-1, -1);
        public bool Book(int start, int end)
        {
            var cur = _root;
            while (cur != null)
            {
                if (start >= cur.End)
                {
                    if (cur.Next == null || end <= cur.Next.Start)
                    {
                        var node = new Node(start, end);
                        node.Next = cur.Next;
                        cur.Next = node;
                        return true;
                    }
                    else
                    {
                        cur = cur.Next;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public class Node
        {
            public Node(int start, int end)
            {
                this.Start = start;
                this.End = end;
            }
            public int Start { set; get; }
            public int End { set; get; }
            public Node Next { set; get; }
        }
    }
}
