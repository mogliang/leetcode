using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace leetcode.problems
{
    [TestClass]
    public class _165
    {
        [TestMethod]
        public void CompareVersionTest()
        {
            Assert.AreEqual(-1, CompareVersion("7.5.2.4", "7.5.3"));
        }

        public int CompareVersion(string version1, string version2)
        {
            var va1= version1.Split('.');
            var va2 = version2.Split('.');
            int length = Math.Max(va1.Length,va2.Length);
            for(int i = 0; i < length; i++)
            {
                var a = i < va1.Length ? int.Parse(va1[i]) : 0;
                var b = i < va2.Length ? int.Parse(va2[i]) : 0;
                if (a > b)
                {
                    return 1;
                }else if (a < b)
                {
                    return -1;
                }
            }

            return 0;
        }
    }
}
