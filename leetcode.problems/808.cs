using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace leetcode.problems
{
    [TestClass]
    public class _808
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = SoupServings(1);
            var result2 = SoupServings(100);
        }

        public double SoupServings(int N)
        {
            N = (int)Math.Ceiling((double)N / 25);
            if (N >= 500) return 1;
            cache = new double[N, N];
            return SoupServings(N, N);
        }

        double[,] cache;
        double SoupServings(int m, int n)
        {
            if (m <= 0)
            {
                if (n <=0) return 0.5;
                else return 1;
            }
            else if (n <= 0)
            {
                return 0;
            }
            else if (cache[m - 1, n - 1] != 0)
            {
                return cache[m - 1, n - 1] - 1;
            }
            else
            {
                cache[m - 1, n - 1] = (SoupServings(m - 4, n) +
                    SoupServings(m - 3, n - 1) +
                    SoupServings(m - 2, n - 2) +
                    SoupServings(m - 1, n - 3)) / 4 + 1;
                return cache[m - 1, n - 1] -1;
            }
        }
    }
}