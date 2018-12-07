using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.g
{
    [TestClass]
    public class g4
    {
        #region FindRedundantDirectedConnection
        [TestMethod]
        public void FindRedundantDirectedConnectionTest()
        {
            var res = FindRedundantDirectedConnection(new int[,]
            {
                {1,2 },
                {2,3 },
                {3,4 },
                {4,1 },
                {1,5 }
            });
        }

        public int[] FindRedundantDirectedConnection(int[,] edges)
        {
            Dictionary<int, int> roots = new Dictionary<int, int>();
            int[] target = null, candidate = null;
            for(int i = 0; i < edges.GetLength(0); i++)
            {
                if (!roots.ContainsKey(edges[i, 1])) // 1 parent check
                {
                    if(findRoot(roots, edges[i, 0]) == edges[i, 1]) // circle check
                    {
                        if (target != null)
                        {
                            return candidate; // 如果circle, 而且之前有double parent, 说明candidate有问题
                        }
                        else
                        {
                            target= new int[] { edges[i, 0], edges[i, 1] }; // 如果circle, 之前没发现double parent, 把当前边放到target
                        }
                    }
                    else
                    {
                        roots[edges[i, 1]] = edges[i, 0];
                    }
                }
                else
                {
                    if (target != null) // 如果双边, 而且之前发现了circle(不可能是另一个双边), 则需要把当前candidate返回
                    {
                        return new int[] { roots[edges[i, 1]], edges[i, 1] };
                    }
                    else
                    {
                        // 如果双边,而之前没问题,则保存下来,
                        target = new int[] { edges[i, 0], edges[i, 1] };
                        candidate = new int[] { roots[edges[i, 1]], edges[i, 1] };
                    }
                }
            }
            // 如果没问题,把之前发现的冲突返回
            return target;
        }

        int findRoot(Dictionary<int,int> dict, int node)
        {
            while (dict.ContainsKey(node))
            {
                node = dict[node];
            }
            return node;
        }

        #endregion

        public bool CanFinish(int numCourses, int[,] prerequisites)
        {

        }
    }
}
