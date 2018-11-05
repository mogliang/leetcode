using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.problems
{
    /// <summary>
    /// https://leetcode.com/problems/unique-substrings-in-wraparound-string/
    /// </summary>
    [TestClass]
    public class _467
    {
        [TestMethod]
        public void FindSubstringInWraproundStringTest()
        {
            Assert.AreEqual(1, FindSubstringInWraproundString("a"));
            Assert.AreEqual(2, FindSubstringInWraproundString("cac"));
            Assert.AreEqual(6, FindSubstringInWraproundString("zab"));
        }

        public int FindSubstringInWraproundString(string p)
        {
            if (p == string.Empty) return 0;
            int[] dict = new int[26];
            dict[p[0]-'a'] = 1;
            int start = 0;
            int oldv = 0, newv = 0;
            for (int i = 1; i < p.Length; i++)
            {
                if (p[i] - p[i - 1] != 1 && !(p[i] == 'a' && p[i - 1] == 'z'))
                {
                    start = i;

                }
                oldv = dict[p[i] - 'a'];
                newv = i - start + 1;
                dict[p[i] - 'a'] = newv > oldv ? newv : oldv;
            }

            int sum = dict.Sum();
            return sum;
        }
    }
}
