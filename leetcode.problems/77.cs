using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace leetcode.problems
{
    /// <summary>
    /// https://leetcode.com/problems/combinations/
    /// </summary>
    [TestClass]
    public class _77
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test = Combine(1, 5, 5);
        }

        public IList<IList<int>> Combine(int n, int k)
        {
            return Combine(1, n, k);
        }

        public IList<IList<int>> Combine(int start, int end, int k)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            if (k > end - start + 1) { return ret; }

            if (k == 1)
            {
                for(int i = start; i <= end; i++)
                {
                    ret.Add(new List<int> { i });
                }
            }
            else
            {
                for(int i = start; i < end; i++)
                {
                    var list = Combine(i + 1, end, k - 1);
                    foreach (var item in list)
                    {
                        item.Insert(0, i);
                        ret.Add(item);
                    }
                }
            }

            return ret;
        }
    }
}
