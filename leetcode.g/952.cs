using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.g
{
    [TestClass]
    public class _952
    {
        [TestMethod]
        public void LargestComponentSizeTest()
        {
            var test = LargestComponentSize(new[] { 4, 6, 15, 35 });
        }

        public int LargestComponentSize(int[] A)
        {
            var primes = findPrime(100000);
            var counts = new int[primes.Count];
            var parents = new int[primes.Count];
            Array.Fill(parents, -1);
            int max = 0;

            for(int i = 0; i < A.Length; i++)
            {
                var a = A[i];
                int lastp = -1;
                int j = Math.Max(0, primes.BinarySearch(a));
                for (; j < primes.Count && a!=1; j++)
                {
                    if (a % primes[j] == 0)
                    {
                        while (a % primes[j] == 0) a = a / primes[j];
                        var parent = findParent(parents, j);

                        if (lastp == -1)
                        {
                            counts[parent]++;
                            max = Math.Max(max, counts[parent]);
                            lastp = j;
                        }
                        else
                        {
                            var parent2 = findParent(parents, lastp);
                            if (parent != parent2)
                            {
                                parents[parent2] = parent;
                                counts[parent] += counts[parent2];
                                max = Math.Max(max, counts[parent]);
                            }
                        }
                    }
                }
            }
            return max;
        }

        int findParent(int[] parents, int idx)
        {
            int cur = idx;
            while (parents[cur] != -1) cur = parents[cur];
            if (parents[idx] != -1) parents[idx] = cur;
            return cur;
        }

        List<int> findPrime(int max)
        {
            var isPrimes = new bool[max + 1];
            Array.Fill(isPrimes, true);

            var primes = new HashSet<int>();
            for (int i = 2; i < max; i++)
            {
                if (isPrimes[i])
                {
                    primes.Add(i);
                    for (int j = i; j <= max; j += i)
                        isPrimes[j] = false;
                }
            }
            return primes.ToList();
        }
    }
}
