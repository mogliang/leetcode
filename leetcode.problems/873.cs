using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.problems
{
    [TestClass]
    public class _873
    {
        [TestMethod]
        public void LenLongestFibSubseqTest()
        {
            Assert.AreEqual(5, LenLongestFibSubseq(new[] {1,2,3,4,5 }));
        }

        public int LenLongestFibSubseq(int[] A)
        {
            cache = new bool[A.Length, A.Length];
            if (A.Length < 3) return 0;
            var max = 0;
            for (int i = 0; i < A.Length; i++)
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (!cache[i, j])
                    {
                        var cur = FibLength(A, i, j);
                        if (cur > max) max = cur;
                    }
                }
            return max == 0 ? 0 : max + 2;
        }

        bool[,] cache;
        int FibLength(int [] A, int aIdx, int bIdx)
        {
            var a = A[aIdx];
            var b = A[bIdx];
            var c = a + b;
            int count = 0;
            for (int i = bIdx + 1; i < A.Length; i++)
            {
                if (A[i] == c)
                {
                    count++;
                    a = b;
                    aIdx = bIdx;
                    b = c;
                    bIdx = i;
                    c = a + b;
                    cache[aIdx, bIdx] = true;
                }
                else if (A[i] > c)
                {
                    break;
                }
            }
            return count;
        }
    }
}
