using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace leetcode.problems
{
    [TestClass]
    public class _204
    {
        [TestMethod]
        public void CountPrimesTest()
        {
            CountPrimes(100);
        }

        public int CountPrimes(int n)
        {
            if (n <= 2) return 0;
            else if (n == 3) return 1;

            bool?[] flags = new bool?[n];
            for(int i = 3; i < n; i+=2)
            {
                if (flags[i]==null)
                {
                    flags[i] = true;
                    for (int j = i * 2; j < n; j += i) flags[j] = false;
                }
            }

            int count = 0;
            for (int i = 3; i < n; i++) count += flags[i]!=null && flags[i].Value ? 1 : 0;
            return count + 1;
        }

        //public int CountPrimes(int n)
        //{
        //    if (n <= 2) return 0;
        //    else if (n == 3) return 1;

        //    primes = new List<int> { 2 };
        //    for (int i = 3; i < n; i++)
        //        if (IsPrime(i)) primes.Add(i);

        //    return primes.Count;
        //}

        //List<int> primes;
        //bool IsPrime(int x)
        //{
        //    var sqrtx = x/2;
        //    for(int i = 0; i < primes.Count; i++)
        //    {
        //        if (primes[i] > sqrtx)
        //            return true;
        //        else if (x % primes[i] == 0)
        //            return false;
        //    }
        //    return true;
        //}
    }
}
