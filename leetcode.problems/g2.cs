using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.problems
{
    [TestClass]
    public class g2
    {
        [TestMethod]
        public void KEmptySlotsTest()
        {
            var val = KEmptySlots(new[] { 1, 3, 4, 5, 7, 6 }, 1);
        }

        public int KEmptySlots(int[] flowers, int k)
        {
            for (int i = 1; i < flowers.Length; i++)
            {
                for(int j = i; j > 0; j--)
                {
                    if (flowers[j] < flowers[j - 1])
                    {
                        var tmp = flowers[j];
                        flowers[j - 1] = flowers[j];
                        flowers[j] = tmp;
                    }
                    else
                    {
                        if (j > 0 && flowers[j] - flowers[j - 1] == k + 1) return i + 1;
                        else if (j < flowers.Length - 1 && flowers[j + 1] - flowers[j] == k + 1) return i + 1;
                        else break;
                    }
                }
            }
            return -1;
        }

        public int KEmptySlots2(int[] flowers, int k)
        {
            int[] bloom = new int[flowers.Length];
            for (int i = 0; i < flowers.Length; i++)
            {
                bloom[flowers[i] - 1] = 1;
                int sum = 0;
                bool hasleftFlower = false;
                for (int j = 0; j < bloom.Length; j++)
                {
                    if (bloom[j] == 0) sum++;
                    else
                    {
                        if (sum == k && hasleftFlower) return i + 1;
                        sum = 0;
                        hasleftFlower = true;
                    }
                }
            }
            return -1;
        }
    }
}
