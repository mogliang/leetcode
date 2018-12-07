using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.g
{
    [TestClass]
    public class g3
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        #region Merge K Lists
        public ListNode MergeKLists(ListNode[] lists)
        {
            var sortlist = lists.ToList();
            for (int i = sortlist.Count - 1; i >= 0; i--)
            {
                if(sortlist[i]==null)
                    sortlist.RemoveAt(i);
            }
            sortlist.Sort((a, b) => a.val - b.val);

            var root = new ListNode(0);
            var cur = root;

            while (sortlist.Count > 0)
            {
                cur.next = sortlist[0];
                cur = cur.next;

                sortlist.RemoveAt(0);
                if (cur.next != null)
                {
                    var pos = binarySearch(sortlist, cur.next.val);
                    sortlist.Insert(pos, cur.next);
                }
            }
            return root.next;
        }

        int binarySearch(List<ListNode> sortlist, int val)
        {
            int left = 0, right = sortlist.Count - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                var midVal = sortlist[mid].val;
                if (midVal == val) return mid;
                else if (midVal > val) { right = mid - 1; }
                else if (midVal < val) { left = mid + 1; }
            }
            return left;
        }
        #endregion

        #region Insert into a Cyclic Sorted List
        public Node Insert(Node head, int insertVal)
        {
            if (head == null)
            {
                head = new Node();
                head.val = insertVal;
                head.next = head;
                return head;
            }

            var root = head;
            var max = head;
            do
            {
                if (head.val <= insertVal && head.next.val >= insertVal)
                {
                    var node2 = new Node(insertVal, head.next);
                    head.next = node2;
                    return root;
                }
                else
                {
                    if (head.val > max.val) max = head;
                    head = head.next;
                }
            } while (head != root);

            var node = new Node(insertVal, max.next);
            max.next = node;
            return root;
        }
        #endregion

        #region Evaluate Division
        public double[] CalcEquation(string[,] equations, double[] values, string[,] queries)
        {
            var dict = new D2Dict<string, string, double>();
            for(int i = 0; i < equations.GetLength(0); i++)
            {
                dict.Set(equations[i, 0], equations[i, 1], values[i]);
                dict.Set(equations[i, 1], equations[i, 0], 1/values[i]);
            }

            var names = dict.Keys.ToList();
            foreach (var key1 in names)
            {
                foreach (var key2 in names)
                {
                    foreach (var key3 in names)
                    {
                        if(!dict[key1].ContainsKey(key3) && dict.TryGet(key1,key2, out double v1) && dict.TryGet(key2,key3, out double v2))
                        {
                            dict.Set(key1, key3, v1 * v2);
                        }
                    }
                }
            }

            var result = new double[queries.GetLength(0)];
            for(int i = 0; i < queries.GetLength(0); i++)
            {
                double v;
                if (!dict.TryGet(queries[i, 0], queries[i, 1], out v)) v = -1;
                result[i] = v;
            }
            return result;
        }

        public class D2Dict<T1, T2, V>
        {
            Dictionary<T1, Dictionary<T2, V>> _dict = new Dictionary<T1, Dictionary<T2, V>>();

            public ICollection<T1> Keys
            {
                get
                {
                    return _dict.Keys;
                }
            }

            public Dictionary<T2,V> this[T1 t1]
            {
                get
                {
                    if (!_dict.ContainsKey(t1))
                    {
                        _dict[t1] = new Dictionary<T2, V>();
                    }
                    return _dict[t1];
                } 
            }

            public bool TryGet(T1 t1, T2 t2, out V v)
            {
                if (_dict.ContainsKey(t1) && _dict[t1].ContainsKey(t2))
                {
                    v = _dict[t1][t2];
                    return true;
                }
                else
                {
                    v = default(V);
                    return false;
                }
            }

            public V Get(T1 t1, T2 t2)
            {
                if (_dict.ContainsKey(t1) && _dict[t1].ContainsKey(t2))
                {
                    return _dict[t1][t2];
                }
                else
                {
                    throw new Exception("key doesn't exist");
                }
            }

            public void Set(T1 t1, T2 t2, V v) {
                if (!_dict.ContainsKey(t1)) _dict[t1] = new Dictionary<T2, V>();
                _dict[t1][t2] = v;
            }
        }

        #endregion

        #region inorder successor in BST
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            return InorderSuccessorImpl(root, p);
        }

        bool _found;
        TreeNode InorderSuccessorImpl(TreeNode root, TreeNode p)
        {
            // 如果为空,直接跳过
            if (root == null) return null;

            // 遍历左侧, 如果找到,直接返回
            var next = InorderSuccessorImpl(root.left, p);
            if (next != null) return next;

            // 左侧没找到,返回当前节点
            if (_found) return root;
            // 左侧没定位
            else _found = root == p;

            // 没找到,交给后续寻找
            return InorderSuccessorImpl(root.right, p);

            // 如果都没找到,返回null
        }
        #endregion
    }
}
