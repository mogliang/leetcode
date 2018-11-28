using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.problems
{
    [TestClass]
    public class _843
    {
        [TestMethod]
        public void FindSecretWordTest()
        {
            var wordlist = new[] { "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi", "hsygda", "vyuica", "mbnagm", "uinqur", "pikenp", "szgupv", "qpxmsw", "vunxdn", "jahhfn", "kmbeok", "biywow", "yvgwho", "hwzodo", "loffxk", "xavzqd", "vwzpfe", "uairjw", "itufkt", "kaklud", "jjinfa", "kqbttl", "zocgux", "ucwjig", "meesxb", "uysfyc", "kdfvtw", "vizxrv", "rpbdjh", "wynohw", "lhqxvx", "kaadty", "dxxwut", "vjtskm", "yrdswc", "byzjxm", "jeomdc", "saevda", "himevi", "ydltnu", "wrrpoc", "khuopg", "ooxarg", "vcvfry", "thaawc", "bssybb", "ccoyyo", "ajcwbj", "arwfnl", "nafmtm", "xoaumd", "vbejda", "kaefne", "swcrkh", "reeyhj", "vmcwaf", "chxitv", "qkwjna", "vklpkp", "xfnayl", "ktgmfn", "xrmzzm", "fgtuki", "zcffuv", "srxuus", "pydgmq" };
            var master = new Master();
            master.secret = "ccoyyo";

            FindSecretWord(wordlist, master);
        }

        public void FindSecretWord(string[] wordlist, Master master)
        {
            var N = wordlist.Length;
            var dis = new int[N, N];
            for(int i=0;i<N;i++)
                for(int j = i + 1; j < N; j++)
                {
                    var sim = 0;
                    for(int k = 0; k < wordlist[i].Length; k++)
                    {
                        if (wordlist[i][k] == wordlist[j][k]) sim++;
                    }
                    dis[i, j] = sim;
                    dis[j, i] = sim;
                }

            var std = new double[N];
            for (int i = 0; i < N; i++)
            {
                var sum = 0;
                for(int j = 0; j < N; j++)
                {
                    sum += dis[i, j];
                }
                var avg = sum / N;
                double cur = 0;
                for(int j = 0; j < N; j++)
                {
                    cur += (dis[i, j] - avg) * (dis[i, j] - avg);
                }
                cur = cur / N;
                std[i] = cur;
            }

            var candidate = new List<int>();
            for (int i = 0; i < N; i++) candidate.Add(i);

            int guessCount = 0;
            var guessList = new List<int>();
            while (guessCount<10)
            {
                double maxStd = -1;
                int max = 0;
                for(int i = 0; i < candidate.Count; i++)
                {
                    if (std[candidate[i]] > maxStd)
                    {
                        maxStd= std[candidate[i]];
                        max = i;
                    }
                }
                var cur = candidate[max];
                guessList.Add(cur);

                var match = master.Guess(wordlist[cur]);
                if (match == wordlist[cur].Length) return;
                else
                {
                    var newCandidate = new List<int>();
                    for(int i = 0; i < N; i++)
                    {
                        if(i!=cur && dis[cur, i] == match)
                        {
                            if (candidate.Contains(i) && !guessList.Contains(i))
                                newCandidate.Add(i);
                        }
                    }
                    candidate = newCandidate;
                }
                guessCount++;
            }
        }

        public class Master
        {
            public string secret;
            public int Guess(string word)
            {
                int c = 0;
                for (int i = 0; i < secret.Length; i++)
                    if (secret[i] == word[i]) c++;
                return c;
            }
        }
    }
}
