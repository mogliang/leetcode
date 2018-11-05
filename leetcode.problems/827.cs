using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.problems
{
    /// <summary>
    /// https://leetcode.com/problems/making-a-large-island/
    /// </summary>
    [TestClass]
    public class _827
    {
        [TestMethod]
        public void LargestIslandTest()
        {
            Assert.AreEqual(3, LargestIsland(new int[][]{
                new int []{1,0 },
                new int []{0,1 }
            }));

            Assert.AreEqual(4, LargestIsland(new int[][]{
                new int []{1,1 },
                new int []{0,1 }
            }));

            Assert.AreEqual(4, LargestIsland(new int[][]{
                new int []{1,1 },
                new int []{1,1 }
            }));

            Assert.AreEqual(1, LargestIsland(new int[][]{
                new int []{1},
            }));
        }

        public int LargestIsland(int[][] grid)
        {
            if(grid.Length==0 || grid[0].Length == 0)
            {
                return 0;
            }

            // 初始化数组
            int[][] grid2 = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                grid2[i] = new int[grid[i].Length];
            }

            // 标记island
            int tag = 1;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1 && grid2[i][j] == 0)
                    {
                        Flood(grid, grid2, i, j, tag);
                        tag++;
                    }
                }
            }

            // 测量大小
            var islandSizeDict = new int[tag];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid2[i][j] > 0)
                    {
                        islandSizeDict[grid2[i][j] - 1]++;
                    }
                }
            }

            int max = 0;
            var calcDict = new int[tag];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid2[i][j] == 0)
                    {
                        Test(grid2, i - 1, j, calcDict);
                        Test(grid2, i + 1, j, calcDict);
                        Test(grid2, i, j - 1, calcDict);
                        Test(grid2, i, j + 1, calcDict);

                        int cur = 1;
                        for (int k = 0; k < tag; k++)
                        {
                            cur += calcDict[k] * islandSizeDict[k];
                            calcDict[k] = 0;
                        }
                        if (max < cur) max = cur;
                    }
                }
            }

            if (max == 0)
            {
                return grid.Length * grid[0].Length;
            }
            else
                return max;
        }

        void Test(int[][] grid2, int x, int y, int[] calcDict)
        {
            if (x < 0 || y < 0 || x >= grid2.Length || y >= grid2[0].Length)
                return;
            if (grid2[x][y] != 0)
            {
                calcDict[grid2[x][y] - 1] = 1;
            }
        }

        void Flood(int[][] grid, int[][] grid2, int x, int y, int tag)
        {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[0].Length)
                return;

            if (grid2[x][y] == 0 && grid[x][y] == 1)
            {
                grid2[x][y] = tag;
                Flood(grid, grid2, x - 1, y, tag);
                Flood(grid, grid2, x + 1, y, tag);
                Flood(grid, grid2, x, y - 1, tag);
                Flood(grid, grid2, x, y + 1, tag);
            }
        }
    }
}
