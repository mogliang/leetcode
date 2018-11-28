using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace leetcode.problems
{
    [TestClass]
    public class _378
    {
        [TestMethod]
        public void KthSmallestTest()
        {
            //var v = KthSmallest(new int[,]
            //{
            //   { 1, 5, 9 },
            //   {10, 11, 13 },
            //   { 12, 13, 15 }
            //}, 8);

            var v2 = KthSmallest(new int[,]
            {
                {1,3, 5},
                {6,7,12 },
                {11,14,14 }
            }, 3);

        }

        public int KthSmallest(int[,] matrix, int k)
        {
            var N = matrix.GetLength(0);
            int smallCount = 0;
            for (int i = 1; i < 2*N; i++)
            {
                var count = i <= N ? i : 2 * N - i;
                if (smallCount + count >= k)
                {
                    var arr = new List<int>(count);
                    if (i <= N)
                    {
                        for(int j = 0; j < count; j++)
                        {
                            arr.Add(matrix[j, i - j - 1]);
                        }
                    }
                    else
                    {
                        for(int j = 0; j < count; j++)
                        {
                            arr.Add(matrix[i - N + j, N - j - 1]);
                        }
                    }
                    arr.Sort();

                    return arr[k - smallCount - 1];
                }
                else
                {
                    smallCount += count;
                }
            }

            return -1;
        }
    }
}
