using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.problems
{
    [TestClass]
    public class _790
    {
        [TestMethod]
        public void NumTilingsTest()
        {
            Assert.AreEqual(1, NumTilings(1));
            Assert.AreEqual(2, NumTilings(2));
            Assert.AreEqual(5, NumTilings(3));
            Assert.AreEqual(11, NumTilings(4));
            Assert.AreEqual(24, NumTilings(5));
            Assert.AreEqual(312342182, NumTilings(30));
        }

        public int NumTilings(int N)
        {
            if (N == 0) return 0;
            cache = new int[N + 1, N + 1];
            return NumTilingsImpl(N, N);
        }

        int[,] cache;
        int NumTilingsImpl(int r1, int r2)
        {
            if (r1 == 0 && r2 == 0)
            {
                return 1;
            }
            else if (r1 < 0 || r2 < 0)
            {
                return 0;
            }
            else if (cache[r1, r2] != 0)
            {
                return cache[r1, r2] - 1;
            }
            else if (r1 == r2)
            {
                cache[r1, r2] = (int)((0L + NumTilingsImpl(r1 - 1, r2 - 1) //|
                    + NumTilingsImpl(r1 - 2, r2 - 2) // =
                    + NumTilingsImpl(r1 - 1, r2 - 2) // L
                    + NumTilingsImpl(r1 - 2, r2 - 1) + 1) % 1000000007); // P
            }
            else if (r1 == r2 + 1)
            {
                cache[r1, r2] = (int)((0L + NumTilingsImpl(r1 - 2, r2)
                    + NumTilingsImpl(r1 - 2, r2 - 1) + 1) % 1000000007);
            }
            else if (r2 == r1 + 1)
            {
                cache[r1, r2] = (int)((0L + NumTilingsImpl(r1, r2 - 2)
                    + NumTilingsImpl(r1 - 1, r2 - 2) + 1) % 1000000007);
            }
            else
            {
                return 0;
            }

            return cache[r1, r2] - 1;
        }

        // After playing around with tiling options, this is the LONG sequence to generate f(N)
        // f(N) = f(N-1) + f(N-2) + 2*f(N-3) + 2*f(N-4) + 2*f(N-5) + ... + 2*f(1) + 2
        //
        // which is effectively the same as:
        // f(N) = 2 * f(N-1) + f(N-3)
        int numTilings(int N)
        {
            // we only need to remember 3 results
            int[] res = new int[] { 1, 2, 5 };

            for (; N > 3; N--)
            {
                int fn3 = res[0];
                int fn1 = res[2];

                // canclulate next, use 64bit just in case to avoid overflow
                long val = 0L + 2 * fn1 + fn3;
                val %= 1000000007;

                // shift and write next val
                res[0] = res[1];
                res[1] = res[2];
                res[2] = (int)val;
            }
            return res[N - 1];
        }
    }
}
