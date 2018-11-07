using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.problems
{
    [TestClass]
    public class _779
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, KthGrammar(4, 5));
        }

        public int KthGrammar(int N, int K)
        {
            if (K == 1) return 0;
            var cur = K - 1;
            bool reverse = cur % 2 == 1;
            while (cur != 1)
            {
                cur = cur / 2;
                if (cur % 2 == 1)
                {
                    reverse ^= true;
                }
            }
            return reverse ? 1 : 0;
        }
    }
}
