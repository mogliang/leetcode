using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.g
{
    public class _949
    {
        public string LargestTimeFromDigits(int[] A)
        {
            var list = A.ToList();
            if (A.Contains(2) && A.Count(a => a < 4) >= 2 && A.Count(a => a < 6) >= 3)
            {
                list.Remove(2);
                var h = list.Where(a => a < 4).Max();
                list.Remove(h);
                var m = list.Where(a => a < 6).Max();
                list.Remove(m);
                return $"2{h}:{m}{list[0]}";
            }
            else if (A.Contains(1) && A.Count(a => a < 6) >= 2)
            {
                list.Remove(1);
                var h = list.Max();
                list.Remove(h);
                var m = list.Where(a => a < 6).Max();
                list.Remove(m);
                return $"1{h}:{m}{list[0]}";
            }
            else if (A.Contains(0) && A.Count(a => a < 6) >= 2)
            {
                list.Remove(0);
                var h = list.Max();
                list.Remove(h);
                var m = list.Where(a => a < 6).Max();
                list.Remove(m);
                return $"0{h}:{m}{list[0]}";
            }
            else return string.Empty;
        }
    }
}
