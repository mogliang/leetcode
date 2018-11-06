using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace leetcode.problems
{
    /// <summary>
    /// https://leetcode.com/problems/cherry-pickup/
    /// </summary>
    [TestClass]
    public class _741
    {
        [TestMethod]
        public void CherryPickupTest()
        {
            var result = CherryPickup(new int[,]
            {
                { 0,1,-1},
                { 1,0,-1},
                {1,1,1 }
            });
        }

        int N;
        int[,] grid;
        int[,,] memo;
        public int CherryPickup(int[,] grid)
        {
            N = grid.GetLength(0);
            this.grid = grid;
            memo = new int[N, N, N]; // r1,c1,c2, (r2=r1+c1-c2)
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    for (int k = 0; k < N; k++)
                        memo[i, j, k] = int.MinValue;

            return Math.Max(0, dp(0, 0, 0));
        }

        int dp(int r1, int c1, int c2)
        {
            int r2 = r1 + c1 - c2;
            if (r1 == N || c1 == N || c2 == N || r2 == N || grid[r1, c1] == -1 || grid[r2, c2] == -1)
            {
                return -99999;
            }else if (r1 == N-1 && c1 == N-1 && c2 == N - 1)
            {
                return grid[N-1,N-1];
            }
            else if (memo[r1, c1, c2] != int.MinValue)
            {
                return memo[r1, c1, c2];
            }
            else
            {
                var vl = grid[r1, c1] + grid[r2, c2] +
                    Math.Max(dp(r1 + 1, c1, c2 + 1),
                        Math.Max(dp(r1 + 1, c1, c2),
                            Math.Max(dp(r1, c1 + 1, c2 + 1), dp(r1, c1 + 1, c2))));
                if(grid[r1,c1]==1 && r1==r2 && c1 == c2)
                {
                    vl--;
                }

                memo[r1, c1, c2] = vl;
                return vl;
            }
        }
    }
}
