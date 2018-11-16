using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.problems
{
    [TestClass]
    public class _115
    {
        [TestMethod]
        public void NumDistinctTest()
        {
            Assert.AreEqual(3, NumDistinct("rabbbit", "rabbit"));
            Assert.AreEqual(5, NumDistinct("babgbag", "bag"));
        }

        // https://leetcode.com/problems/distinct-subsequences/discuss/37327/Easy-to-understand-DP-in-Java
        public int NumDistinct(string s, string t)
        {
            var dict = new int[t.Length + 1, s.Length + 1];
            for (int i = 0; i <= s.Length; i++) dict[0, i] = 1;
            for (int j = 1; j <= t.Length; j++) dict[j, 0] = 0;
            for (int i = 1; i <= t.Length; i++)
                for (int j = 1; j <= s.Length; j++)
                    dict[i, j] = s[j - 1] == t[i - 1] ? dict[i - 1, j - 1] + dict[i, j - 1] : dict[i, j - 1];

            return dict[t.Length, s.Length];
        }

        //public int NumDistinct(string s, string t)
        //{
        //    var dict = new int[s.Length+1, 52];
        //    for (int i = s.Length; i > 0; i--)
        //    {
        //        for (int j = 0; j < i; j++)
        //        {
        //            dict[j, s[i - 1] - 'A'] = i;
        //        }
        //    }

        //    return NumDistinctImpl(dict, t, 0, 0);
        //}

        //// dict, t, 当前t位置, s位置
        //public int NumDistinctImpl(int[,] dict, string t, int pos, int sPos)
        //{
        //    if (pos == t.Length) return 1;

        //    var count = 0;
        //    var c = t[pos];
        //    do
        //    {
        //        sPos = dict[sPos, c - 'A'];
        //        if (sPos != 0)
        //        {
        //            count += NumDistinctImpl(dict, t, pos + 1, sPos);
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    } while (true);

        //    return count;
        //}

        //public int NumDistinct(string s, string t)
        //{
        //    // O(m)
        //    var dict = new Dictionary<char, List<int>>();
        //    for(int i=0;i<s.Length;i++)
        //    {
        //        var c = s[i];
        //        if (!dict.ContainsKey(c))
        //        {
        //            dict[c] = new List<int>();
        //        }
        //        dict[c].Add(i);
        //    }

        //    var idxs = new Dictionary<char,int>();
        //    foreach (var key in dict.Keys)
        //    {
        //        idxs[key] = -1;
        //    }

        //    return NumDistinctImpl(dict, idxs, t, 0, -1);
        //}

        //int NumDistinctImpl(Dictionary<char, List<int>> dict, Dictionary<char, int> idxs, string t, int pos, int sPos)
        //{
        //    if (pos >= t.Length) return 1;
        //    else if (!dict.ContainsKey(t[pos])) return 0;

        //    var count = 0;
        //    var c = t[pos];
        //    var old = idxs[c];
        //    for(int i = idxs[c] + 1; i < dict[c].Count; i++)
        //    {
        //        if (dict[c][i] <= sPos) continue;
        //        idxs[c]=i;
        //        count += NumDistinctImpl(dict, idxs, t, pos + 1, dict[c][i]);
        //    }
        //    idxs[c] = old;
        //    return count;
        //}
    }
}
