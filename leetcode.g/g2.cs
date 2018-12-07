using leetcode.g;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.problems
{
    [TestClass]
    public class g2
    {
        [TestMethod]
        public void KEmptySlotsTest()
        {
            var t2 = IsNumber(". 1");
            var t= IsPalindrome("A man, a plan, a canal: Panama");
            var val = NextClosestTime("13:55");
            //var val = KEmptySlots(new[] { 1,2,3,4,5,7,6}, 1);
        }

        public int KEmptySlots(int[] flowers, int k)
        {
            if (k > flowers.Length - 2) return -1;

            // 生成倒排
            var bloom = new int[flowers.Length];
            for (int i = 0; i < flowers.Length; i++) bloom[flowers[i] - 1] = i;

            // 初始化窗口(最左边) 
            int left = 0, right = k + 1;
            int res = int.MaxValue;
            for (int i = 1; i < flowers.Length; i++)
            {
                if (i == right)
                {
                    res = Math.Min(res, Math.Max(bloom[left], bloom[right]));
                    left = i;
                    right = i + k + 1;
                    if (right >= flowers.Length) break;
                }
                else if (bloom[i] < bloom[left] || bloom[i] < bloom[right])
                {
                    left = i;
                    right = i + k + 1;
                    if (right >= flowers.Length) break;
                }
            }
            return res == int.MaxValue ? -1 : res + 1;
        }

        public int KEmptySlots3(int[] flowers, int k)
        {
            for (int i = 1; i < flowers.Length; i++)
            {
                int j = 0;
                for (j = i; j > 0; j--)
                {
                    if (flowers[j] < flowers[j - 1])
                    {
                        var tmp = flowers[j];
                        flowers[j] = flowers[j - 1];
                        flowers[j - 1] = tmp;
                    }
                    else
                    {
                        break;
                    }
                }

                if (j > 0 && flowers[j] - flowers[j - 1] == k + 1) return i + 1;
                else if (j < i && flowers[j + 1] - flowers[j] == k + 1) return i + 1;
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

        public string NextClosestTime(string time)
        {
            var list = new List<int>();
            foreach (var c in time)
            {
                if (c >= '0' && c <= '9' && !list.Contains(c - '0'))
                    list.Add(c - '0');
            }
            list.Sort();

            var arr = time.Split(':');
            var hh = int.Parse(arr[0]);
            var mm = int.Parse(arr[1]);

            var idx = list.IndexOf(mm % 10);
            if (idx < list.Count - 1) return arr[0] + ":" + (mm / 10 * 10 + list[idx + 1]).ToString("00");

            idx = list.IndexOf(mm / 10);
            if (idx < list.Count - 1 && list[idx + 1] < 6) return arr[0] + ":" + (list[idx + 1] * 10 + list[0]).ToString("00");

            idx = list.IndexOf(hh % 10);
            if (idx < list.Count - 1 && ((hh / 10 == 2 && list[idx + 1] < 4) || hh / 10 < 2)) return (hh / 10 * 10 + list[idx + 1]).ToString("00") + ":" + list[0] + list[0];

            idx = list.IndexOf(hh / 10);
            if (idx < list.Count - 1 && list[idx + 1] < 3) return (list[idx + 1] * 10 + list[0]).ToString("00") + ":" + list[0] + list[0];

            return $"{list[0]}{list[0]}:{list[0]}{list[0]}";
        }

        public int LongestUnivaluePath(TreeNode root)
        {
            return LongestUnivaluePathImpl(root).Max;
        }

        Result LongestUnivaluePathImpl(TreeNode root)
        {
            if (root == null) return new Result { Max = 0, CurLength = 0 };
            var left = LongestUnivaluePathImpl(root.left);
            var right = LongestUnivaluePathImpl(root.right);

            int curLength = 0;
            int curOpenLength = 0;
            if(root.left!=null && root.left.val == root.val)
            {
                curLength = left.CurLength + 1;
                curOpenLength = curLength;
            }
            if(root.right!=null && root.right.val == root.val)
            {
                curLength += (right.CurLength + 1);
                curOpenLength = Math.Max(curOpenLength, right.CurLength + 1);
            }
            return new Result { CurLength = curOpenLength, Max = Math.Max(Math.Max(left.Max, right.Max), curLength) };
        }

        public class Result
        {
            public int Max;
            public int CurLength;
        }

        public int Trap(int[] height)
        {
            int high = -2;
            int highIdx = -1;
            for(int i=0;i<height.Length;i++)
                if (height[i] > high)
                {
                    high = height[i];
                    highIdx = i;
                }

            int leftHigh = -1;
            int sum = 0;
            for(int i = 0; i < highIdx; i++)
            {
                if (leftHigh > height[i])
                {
                    sum += leftHigh - height[i];
                }
                else
                {
                    leftHigh = height[i];
                }
            }

            int rightHigh = -1;
            for(int i = height.Length - 1; i > highIdx; i--)
            {
                if(rightHigh> height[i])
                {
                    sum += rightHigh - height[i];
                }
                else
                {
                    rightHigh = height[i];
                }
            }

            return sum;
        }

        //public int Read(char[] buf, int n)
        //{
        //    int count = n / 4;
        //    int left = n % 4;
        //    int idx = 0;
        //    int sum = 0;
        //    for (int i = 0; i < count; i++)
        //    {
        //        var length = Math.Min(buf.Length - idx, 4);
        //        sum += length;
        //        if (length == 0) return sum;

        //        var buf2 = new char[length];
        //        buf2.
        //        buf.CopyTo(buf2, idx);

        //        idx += length;
        //        Read4(buf2);
        //    }

        //    if (left > 0 && idx < buf.Length)
        //    {
        //        var length = Math.Min(buf.Length - idx, left);
        //        var buf2 = new char[length];
        //        buf.CopyTo(buf2, idx);
        //        Read4()
        //    }
        //}



        int Read4(char[] buf) { return 0; }

        public bool IsOneEditDistance(string s, string t)
        {
            string a = null;
            string b = null;
            if (s.Length > t.Length) {
                a = t;
                b = s;
            }
            else
            {
                a = s;
                b = t;
            }

            if (a.Length == b.Length)
            {
                bool diff = false;
                for(int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        if (!diff) diff = true;
                        else return false;
                    }
                }
                return diff;
            }

            else if(a.Length == b.Length - 1)
            {
                bool diff = false;
                for(int i = 0; i < a.Length; i++)
                {
                    if(!diff && a[i] != b[i])
                    {
                        diff = true;
                    }
                    else if(diff && a[i - 1] != b[i])
                    {
                        return false;
                    }
                }
                if (diff)
                {
                    return a[a.Length - 1] == b[b.Length - 1];
                }
                else return true;
            }

            else return false;
        }

        #region IsPalindrome
        public bool IsPalindrome(string s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                while (left < s.Length && !isChar(s[left])) left++;
                while (right >= 0 && !isChar(s[right])) right--;
                if (left == s.Length) return right == -1;
                if (getChar(s[left]) != getChar(s[right]))
                    return false;

                left++;
                right--;
            }
            return true;
        }

        char getChar(char c)
        {
            if (c >= 'A' && c <= 'Z') return (char)(c + 32);
            else return c;
        }

        bool isChar(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c>='0' && c<='9');
        }
        #endregion

        #region IsNumber
        public bool IsNumber(string s)
        {
            s = s.Trim(' ');
            var strs = s.Split('e');
            if (strs.Length > 2) return false;
            else if (strs.Length == 2) return isDecimal(strs[0]) && isInt(strs[1]);
            else return isDecimal(s);
        }

        bool isInt(string s)
        {
            if (s.Length == 0) return false;
            if (s.StartsWith('+') || s.StartsWith('-')) s = s.Substring(1);

            int numCount = 0;
            foreach (var c in s)
            {
                if (c >= '0' && c <= '9') numCount++;
                else return false;
            }
            return numCount > 0;
        }

        bool isDecimal(string s)
        {
            if (s.Length == 0) return false;
            if (s.StartsWith('+') || s.StartsWith('-')) s = s.Substring(1);

            int dotCount = 0;
            int numCount = 0;
            foreach (var c in s)
            {
                if (c == '.') dotCount++;
                else if (c >= '0' && c <= '9') numCount++;
                else return false;
            }
            return numCount > 0 && dotCount <= 1;
        }
        #endregion

        #region IsValidParentheses
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                switch (c)
                {
                    case '}':
                        if (stack.Count==0 || stack.Pop() != '{') return false;
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[') return false;
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(') return false;
                        break;
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(c);
                        break;
                    default:
                        return false ;
                }
            }
            return stack.Count == 0;
        }
        #endregion

        #region Image Smoother
        int _m, _n;
        public int[,] ImageSmoother(int[,] M)
        {
            _m = M.GetLength(0);
            _n = M.GetLength(1);
            var res = new int[_m, _n];
            for(int i=0;i< _m; i++)
                for(int j = 0; j < _n; j++)
                {
                    res[i, j] = SmoothImpl(M, i, j);
                }

            return res;
        }

        int SmoothImpl(int[,] M, int x, int y)
        {
            int x0 = Math.Max(0, x - 1);
            int y0 = Math.Max(0, y - 1);
            int x1 = Math.Min(_m - 1, x + 1);
            int y1 = Math.Min(_n - 1, y + 1);

            int count = 0;
            int sum = 0;
            for(int i=x0;i<=x1;i++)
                for(int j = y0; j <= y1; j++)
                {
                    count++;
                    sum += M[i, j];
                }
            return sum / count;
        }
        #endregion

        #region Intersection of Two Arrays
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            var longArr = nums1.Length > nums2.Length ? nums1 : nums2;
            var shortArr = nums1.Length > nums2.Length ? nums2 : nums1;

            var list1 = longArr.ToList();
            list1.Sort();

            var hashSet = new HashSet<int>();
            foreach (var item in shortArr)
            {
                if (list1.BinarySearch(item) >= 0)
                    hashSet.Add(item);
            }
            return hashSet.ToArray();
        }

        public int[] Intersection2(int[] nums1, int[] nums2)
        {
            var hs = new HashSet<int>();
            var res = new HashSet<int>();
            foreach (var item in nums1) hs.Add(item);
            foreach (var item in nums2) if (hs.Contains(item)) res.Add(item);
            return res.ToArray();
        }
        #endregion
    }
}
