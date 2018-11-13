using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.problems
{
    [TestClass]
    public class NumMatrix
    {
        public NumMatrix() { }

        [TestMethod]
        public void SumRegionTest()
        {
            var matrix = new NumMatrix(new int[,]
            {
                { 1, }
            });
            var value = matrix.SumRegion(0,0,0,0);
        }

        int[,] matrix;
        int[,] sumMatrix;
        public NumMatrix(int[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            sumMatrix = new int[rows, cols];

            if(rows>0 && cols > 0)
            {
                sumMatrix[0, 0] = matrix[0, 0];
                for (int i = 1; i < rows; i++) sumMatrix[i, 0] = sumMatrix[i - 1, 0] + matrix[i, 0];
                for (int j = 1; j < cols; j++) sumMatrix[0, j] = sumMatrix[0, j - 1] + matrix[0, j];
                for (int i = 1; i < rows; i++)
                    for (int j = 1; j < cols; j++)
                        sumMatrix[i, j] = sumMatrix[i - 1, j] + sumMatrix[i, j - 1] - sumMatrix[i - 1, j - 1] + matrix[i, j];
            }
        }


        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            if (row1 >= sumMatrix.GetLength(0) || col1 >= sumMatrix.GetLength(1)) return 0;

            var d = sumMatrix[row2, col2];
            var a = (row1 > 0 && col1 > 0) ? sumMatrix[row1 - 1, col1 - 1] : 0;
            var b = col1 > 0 ? sumMatrix[row2, col1 - 1] : 0;
            var c = row1 > 0 ? sumMatrix[row1 - 1, col2] : 0;
            return d + a - b - c;
        }
    }

    /**
     * Your NumMatrix object will be instantiated and called as such:
     * NumMatrix obj = new NumMatrix(matrix);
     * int param_1 = obj.SumRegion(row1,col1,row2,col2);
     */
}
