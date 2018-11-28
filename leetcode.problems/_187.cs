using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.problems
{
    [TestClass]
    public class _187
    {
        [TestMethod]
        public void FindRepeatedDnaSequencesTest()
        {
            var list = FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT");
        }

        public IList<string> FindRepeatedDnaSequences(string s)
        {
            List<string> result = new List<string>();

            // O(n)
            int[] pos = new int[10];
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < s.Length; i++)
            {
                int bit = 0;
                switch (s[i])
                {
                    case 'A':
                        bit = 1;
                        break;
                    case 'C':
                        bit = 2;
                        break;
                    case 'G':
                        bit = 3;
                        break;
                    case 'T':
                        bit = 4;
                        break;
                }

                for (int j = pos.Length - 2; j >= 0; j--)
                {
                    if (pos[j] != 0)
                    {
                        pos[j + 1] = (pos[j] << 3) + bit;
                        if (j == pos.Length - 2)
                        {
                            var tmp = pos[j + 1];
                            if (!dict.ContainsKey(tmp)) dict[tmp] = 1;
                            else dict[tmp]++;
                            if(dict[tmp]==2)result.Add(Print(tmp));
                        }
                    }
                }
                pos[0] = bit;
            }
            return result;
        }

        string Print(int value)
        {
            var sb = new StringBuilder(10);
            while (value != 0)
            {
                var cur = value & 7;
                value = value >> 3;
                switch (cur)
                {
                    case 1:
                        sb.Insert(0, 'A');
                        break;
                    case 2:
                        sb.Insert(0, 'C');
                        break;
                    case 3:
                        sb.Insert(0, 'G');
                        break;
                    case 4:
                        sb.Insert(0, 'T');
                        break;
                }
            }
            return sb.ToString();
        }

        //public IList<string> FindRepeatedDnaSequences(string s)
        //{
        //    List<string> result = new List<string>();

        //    // O(n)
        //    TileTreeNode[] pos = new TileTreeNode[10];
        //    var root = new TileTreeNode("");
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        for (int j = pos.Length - 2; j >= 0; j--)
        //        {
        //            if (pos[j] != null)
        //            {
        //                pos[j + 1] = pos[j].GoNext(s[i]);
        //                if (j == pos.Length - 2)
        //                {
        //                    pos[j + 1].Value++;
        //                    if (pos[j + 1].Value == 2) result.Add(pos[j + 1].Prefix);
        //                }
        //            }
        //        }
        //        pos[0] = root.GoNext(s[i]);
        //    }
        //    return result;
        //}

        //public class TileTreeNode
        //{
        //    public TileTreeNode(string prefix)
        //    {
        //        this.Prefix = prefix;
        //        Next = new TileTreeNode[4];
        //    }

        //    public string Prefix { set; get; }
        //    public int Value { set; get; }

        //    public TileTreeNode GoNext(char c)
        //    {
        //        switch (c)
        //        {
        //            case 'A':
        //                if (Next[0] == null) Next[0] = new TileTreeNode(Prefix+'A');
        //                return Next[0];
        //            case 'C':
        //                if (Next[1] == null) Next[1] = new TileTreeNode(Prefix + 'C');
        //                return Next[1];
        //            case 'G':
        //                if (Next[2] == null) Next[2] = new TileTreeNode(Prefix + 'G');
        //                return Next[2];
        //            case 'T':
        //                if (Next[3] == null) Next[3] = new TileTreeNode(Prefix + 'T');
        //                return Next[3];
        //            default:
        //                return null;
        //        }
        //    }

        //    public TileTreeNode[] Next { set; get; }
        //}
    }
}
