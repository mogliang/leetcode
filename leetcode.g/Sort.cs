using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace leetcode.g
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        public void BigIntSortShallWorks()
        {
            //// 生成测试数据
            //var list = new List<int>();
            //var rand = new Random();
            //for (int i = 100000; i > 0; i--) list.Add(rand.Next(100000));
            //var str = string.Join(',', list);
            //File.WriteAllText(@"d:\list.txt", str);

            var txt = File.ReadAllText(@"100000.txt");
            var arr = txt.Split(',').Select(s => int.Parse(s)).ToArray();
            var arr2 = txt.Split(',').Select(s => int.Parse(s)).ToArray();

            Stopwatch sw = Stopwatch.StartNew();
            arr.QuickSort((a, b) => a - b);
            var timeToken = sw.ElapsedMilliseconds;


            sw.Restart();
            Array.Sort(arr2, (a, b) => a - b);
            var timeToken2 = sw.ElapsedMilliseconds;

            for(int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(arr[i], arr2[i]);
            }
        }

        [TestMethod]
        public void IntSortShallWorks()
        {

            var arr = new[] { 3, 5, 7, 2, 45, 8, 3, 1, 1 };
            arr.MergeSort((a, b) => a - b);

            var arr2 = new[] { 3 };
            arr2.QuickSort((a, b) => a - b);

            var arr3 = new int [] { };
            arr3.QuickSort((a, b) => a - b);

            int[] arr4 = null;
            arr4.QuickSort((a, b) => a - b);
        }
    }

    public static class ArrayEx
    {
        #region quick sort
        public static void QuickSort<T>(this T[] array, Func<T, T, int> compare)
        {
            if (array == null) return;
            QuickSortImpl(array, 0, array.Length - 1, compare);
        }

        static void QuickSortImpl<T>(T[] array, int start, int end, Func<T, T, int> compare)
        {
            if (end <= start) return;
            T midval = array[start];

            int left = start, right = end;
            while (left != right)
            {
                // 从右侧选择一个小于等于midval的,填写到左侧游标
                // 因为左侧游标初始是start, 所以最后要把它填写到最后的位置
                while (right > left && compare(array[right], midval) > 0) right--;
                if (left != right) array[left] = array[right];

                // 从左侧选择一个大于midval的,填写到右侧游标
                // 右侧游标位置val已经赋值给左边,所以可以覆盖
                while (left < right && compare(array[left], midval) <= 0) left++;
                if (left != right) array[right] = array[left];
            }
            array[left] = midval;

            QuickSortImpl(array, start, left - 1, compare);
            QuickSortImpl(array, left + 1, end, compare);
        }
        #endregion

        #region merge sort
        public static void MergeSort<T>(this T[] array, Func<T, T, int> compare)
        {
            if (array == null) return;
            var buffer = new T[array.Length];
            MergeSortImpl(array, 0, array.Length - 1, compare, buffer);
        }

        static void MergeSortImpl<T>(T[] array, int start, int end, Func<T, T, int> compare, T[] buffer)
        {
            if (end == start)
            {
                return;
            }
            else
            {
                var mid = (start + end) / 2;
                MergeSortImpl(array, start, mid, compare, buffer);
                MergeSortImpl(array, mid + 1, end, compare, buffer);

                int a = start;
                int b = mid + 1;
                for (int i = start; i <= end; i++)
                {
                    if (b>end || (a <= mid && compare(array[a], array[b]) <= 0))
                    {
                        buffer[i] = array[a++];
                    }
                    else
                    {
                        buffer[i] = array[b++];
                    }
                }
                for (int i = start; i <= end; i++)
                    array[i] = buffer[i];
            }
        }
        #endregion

        #region insert sort
        public static void InsertSort<T>(this T[] array, Func<T, T, int> compare)
        {
            if (array == null || array.Length < 2) return;
            for(int i = 1; i < array.Length; i++)
            {
                for(int j = i; j > 0; j--)
                {
                    if (compare(array[j], array[j - 1]) < 0)
                    {
                        var tmp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = tmp;
                    }
                    else break;
                }
            }
        }
        #endregion
    }
}
