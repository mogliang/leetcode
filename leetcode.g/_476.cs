using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.g
{
    [TestClass]
    public class _476
    {
        [TestMethod]
        public void FindComplementTest()
        {
            var test3 = MedianSlidingWindow(new[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);

            //var test =  FindComplement(1);

            //var test2 = LicenseKeyFormatting("5F3Z-2e-9-w-1", 4);
        }

        public int FindComplement(int num)
        {
            long i = 1;
            while (i < num) i = i << 1;
            if (i == num) return (int)(i-1);
            i--;
            return (int)(num ^ i);
        }

        public string LicenseKeyFormatting(string S, int K)
        {
            int count = 0;
            foreach (var c in S)
            {
                if (c == '-') count++;
            }

            var realCount = S.Length - count;
            if (realCount == 0) return string.Empty;

            var lead = realCount % K;
            bool isLead = lead!=0;
            var sb = new StringBuilder(S.Length + realCount / K + 1);

            int sep = 0;
            foreach (var c in S)
            {
                if (c != '-')
                {
                    char t = c >= 'a' && c <= 'z' ? (char)(c - 32) : c;
                    sb.Append(t);
                    sep++;
                    if(isLead && sep == lead)
                    {
                        isLead = false;
                        sb.Append('-');
                        sep = 0;
                    }else if(!isLead && sep == K)
                    {
                        sb.Append('-');
                        sep = 0;
                    }
                }
            }
            if (sb[sb.Length - 1] == '-') sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            List<int> sortWindow = new List<int>();
            for(int i = 0; i < k; i++)
            {
                sortWindow.Add(nums[i]);
            }
            sortWindow.Sort();
            var res = new List<double>();
            res.Add(GetMedian(sortWindow));

            // O(n*k)
            for (int i = 1; i < nums.Length-k+1; i++) // n
            {
                var idx = sortWindow.BinarySearch(nums[i - 1]); // logk
                sortWindow.RemoveAt(idx);
                var newval = nums[i + k - 1];
                idx = sortWindow.BinarySearch(newval);
                if (idx >= 0) sortWindow.Insert(idx, newval);
                else sortWindow.Insert(~idx, newval);
                res.Add(GetMedian(sortWindow));
            }

            return res.ToArray();
        }

        double GetMedian(List<int> sortWindow)
        {
            if (sortWindow.Count % 2 == 1)
            {
                return sortWindow[sortWindow.Count / 2];
            }
            else
            {
                return ((double)sortWindow[sortWindow.Count / 2] + sortWindow[sortWindow.Count / 2 - 1]) / 2;
            }
        }
    }
}
