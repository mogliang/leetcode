using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace leetcode.problems
{
    [TestClass]
    public class _54
    {
        [TestMethod]
        public void SpiralOrderTest()
        {
            var list = SpiralOrder(new[,]
            {
                { 1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            });

            var list2 = SpiralOrder(new[,]
            {
                { 1}
            });
        }

        public IList<int> SpiralOrder(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return new List<int>();
            var list = new List<int>(matrix.GetLength(0) * matrix.GetLength(1));
            SpiralOrderImpl(matrix, list, 0, 0, matrix.GetLength(0) - 1, matrix.GetLength(1) - 1, 0);
            return list;
        }

        void SpiralOrderImpl(int[,] matrix, IList<int> list, int x1, int y1, int x2, int y2, int direction)
        {
            if (x1 > x2 || y1 > y2) return;
            switch (direction)
            {
                case 0: // >
                    for (int i = y1; i <= y2; i++) list.Add(matrix[x1, i]);
                    SpiralOrderImpl(matrix, list, x1 + 1, y1, x2, y2, (direction + 1) % 4);
                    break;
                case 1: // v
                    for (int i = x1; i <= x2; i++) list.Add(matrix[i, y2]);
                    SpiralOrderImpl(matrix, list, x1, y1, x2, y2 - 1, (direction + 1) % 4);
                    break;
                case 2: // <
                    for (int i = y2; i >= y1; i--) list.Add(matrix[x2, i]);
                    SpiralOrderImpl(matrix, list, x1, y1, x2 - 1, y2, (direction + 1) % 4);
                    break;
                case 3: // ^
                    for (int i = x2; i >= x1; i--) list.Add(matrix[i, y1]);
                    SpiralOrderImpl(matrix, list, x1, y1 + 1, x2, y2, (direction + 1) % 4);
                    break;
                default:
                    break;
            }
        }
    }
}
