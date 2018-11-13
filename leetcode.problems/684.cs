using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.problems
{
    [TestClass]
    public class _684
    {
        [TestMethod]
        public void FindRedundantConnectionTest()
        {
            //         //[[1,2], [2,3], [3,4], [1,4], [1,5]]
            var result = FindRedundantConnection(new[,]
            {
                {3,4 },
                {1,2 },
                {2,4 },
                {3,5 },
                {2,5 }
            });
        }

        public int[] FindRedundantConnection(int[,] edges)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                var v1 = edges[i, 0];
                var v2 = edges[i, 1];

                if (!dict.ContainsKey(v1))
                {
                    if (!dict.ContainsKey(v2))
                    {
                        dict[v1] = Math.Max(v1, v2);
                        dict[v2] = Math.Max(v1, v2);
                    }
                    else
                    {
                        dict[v1] = dict[v2];
                    }
                }
                else
                {
                    if (!dict.ContainsKey(v2))
                    {
                        dict[v2] = dict[v1];
                    }
                    else if( dict[v1]!=dict[v2]) // ºÏ²¢
                    {
                        var old = dict[v2];

                        var keys = dict.Keys.ToList();
                        foreach (var key in keys)
                        {
                            if (dict[key] == old)
                                dict[key] = dict[v1];
                        }
                    }
                    else
                    {
                        return new[] { v1, v2 };
                    }
                }
            }
            return null;
        }
    }
}
