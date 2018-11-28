using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace leetcode.problems
{
    [TestClass]
    public class _847
    {
        [TestMethod]
        public void ShortestPathLengthTest()
        {
            var result = ShortestPathLength(new int[][]{
                new []{ 1,2,3},
                new []{ 0 },
                new []{0 },
                new []{0 }
            });
        }

        // https://leetcode.com/problems/shortest-path-visiting-all-nodes/
        // 广度优先搜索, 第一个搜到的就是最短的
        public int ShortestPathLength(int[][] graph)
        {
            var nodeCount = graph.GetLength(0);
            int?[,] dist = new int?[1 << nodeCount, nodeCount];

            var queue = new Queue<State>();
            for (int i = 0; i < nodeCount; i++)
            {
                var curState = new State(1 << i, i);
                dist[curState.Cover, curState.Head] = 0;
                queue.Enqueue(curState);
            }

            while (queue.Count > 0)
            {
                var curState = queue.Dequeue();
                if (curState.Cover == (1 << nodeCount) - 1)
                    return dist[curState.Cover, curState.Head].Value;
                foreach (var newHead in graph[curState.Head])
                {
                    var newCover = curState.Cover | (1 << newHead);
                    var newDist = dist[curState.Cover, curState.Head] + 1;

                    // 只有更小的状态应该保存
                    if (dist[newCover, newHead]==null || newDist < dist[newCover, newHead])
                    {
                        dist[newCover, newHead] = newDist;
                        queue.Enqueue(new State(newCover, newHead));
                    }
                }
            }
            return -1;
        }

        public class State
        {
            public State(int cover, int head) { Cover = cover; Head = head; }
            public int Cover { set; get; }
            public int Head { set; get; }
        }
    }
}
