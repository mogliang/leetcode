using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.problems
{
    [TestClass]
    public class _50
    {
        [TestMethod]
        public void MyPowTest()
        {
            Assert.AreEqual(1024, MyPow(2, 10));
            Assert.AreEqual(9.261, MyPow(2.1, 3));
        }

        public double MyPow(double x, int n)
        {
            if (n == 0) return 1;

            long nn = n > 0 ? n : 0L - n;
            x = n > 0 ? x : 1 / x;
            return MyPowImpl(x, nn);
        }

        public double MyPowImpl(double x, long n)
        {
            if (n == 1)
            {
                return x;
            }
            else if (n % 2 == 0)
            {
                var v = MyPowImpl(x, n / 2);
                return v * v;
            }
            else
            {
                var v = MyPowImpl(x, n / 2);
                return v * v * x;
            }
        }
    }
}
