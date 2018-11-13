using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.problems
{
    [TestClass]
    public class _678
    {
        [TestMethod]
        public void CheckValidStringTest()
        {
            Assert.AreEqual(false, CheckValidString("(*))"));
        }

        bool?[,] cache;
        public bool CheckValidString(string s)
        {
            cache = new bool?[s.Length, s.Length];
            return CheckValidStringImpl (s, 0, 0);
        }

        public bool CheckValidStringImpl(string s, int idx, int leftCount)
        {
            if (idx == s.Length)
                return leftCount == 0;
            else if (leftCount < 0)
                return false;
            else if (cache[idx, leftCount] != null)
            {
                return cache[idx, leftCount].Value;
            }
            else if (s[idx] == ')')
                cache[idx, leftCount] = CheckValidStringImpl(s, idx + 1, leftCount - 1);
            else if (s[idx] == '(')
                cache[idx, leftCount] = CheckValidStringImpl(s, idx + 1, leftCount + 1);
            else // *
                cache[idx, leftCount] = CheckValidStringImpl(s, idx + 1, leftCount - 1) ||
                    CheckValidStringImpl(s, idx + 1, leftCount + 1) ||
                    CheckValidStringImpl(s, idx + 1, leftCount);
            return cache[idx, leftCount].Value;
        }

        public bool CheckValidString2(string s)
        {
            int left = 0;
            int star = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    left++;
                }else if (s[i] == ')')
                {
                    if (left > 0) left--;
                    else if (star > 0) star--;
                    else return false;
                }
                else
                {
                    star++;
                }
            }
            return left == 0;
        }
    }
}
