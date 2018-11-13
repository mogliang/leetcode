using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.problems
{
    [TestClass]
    public class _240
    {
        [TestMethod]
        public void SearchMatrixTest()
        {
            Assert.IsFalse(SearchMatrix(new[,]
            {
                { 1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            }, 20));

            Assert.IsTrue(SearchMatrix(new[,]
            {
                { 1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            }, 18));
        }

        public bool SearchMatrix(int[,] matrix, int target)
        {
            return SearchMatrix(matrix, target, 0, 0, matrix.GetLength(0) - 1, matrix.GetLength(1) - 1);
        }

        public bool SearchMatrix(int[,] matrix, int target, int rstart, int cstart, int rend, int cend)
        {
            var rmid = (rstart + rend) / 2;
            var cmid = (cstart + cend) / 2;

            if (rstart > rend || cstart > cend)
            {
                return false;
            }
            else if (matrix[rmid, cmid] == target)
            {
                return true;
            }
            else if (rstart == rend && cstart == cend)
            {
                return false;
            }
            else if (matrix[rmid, cmid] > target)
            {
                return SearchMatrix(matrix, target, rstart, cstart, rmid - 1, cend) ||
                    SearchMatrix(matrix, target, rmid, cstart, rend, cmid - 1);
            }
            else// (matrix[rmid, cmid] < target)
            {
                return SearchMatrix(matrix, target, rmid + 1, cstart, rend, cend) ||
                    SearchMatrix(matrix, target, rstart, cmid + 1, rmid, cend);
            }
        }
    }
}
