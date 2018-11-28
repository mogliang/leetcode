using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace leetcode.problems
{
    [TestClass]
    public class _427
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        public Node Construct(int[][] grid)
        {
            return Construct(grid, 0, 0, grid.Length);
        }

        Node Construct(int[][] grid, int row1, int col1, int scale)
        {
            var count = 0;
            for (int i = row1; i < row1 + scale; i++)
                for (int j = col1; j < col1 + scale; j++)
                    if (grid[i][j] == 1) count++;
            var node = new Node();

            if (count == scale * scale)
            {
                node.val = true;
                node.isLeaf = true;
                return node;
            }
            else if (count == 0)
            {
                node.val = false;
                node.isLeaf = true;
                return node;
            }
            else
            {
                node.isLeaf = false;
                node.topLeft = Construct(grid, row1, col1, scale / 2);
                node.topRight = Construct(grid, row1, col1 + scale / 2, scale / 2);
                node.bottomLeft = Construct(grid, row1 + scale / 2, col1, scale / 2);
                node.bottomRight = Construct(grid, row1 + scale / 2, col1 + scale / 2, scale / 2);
            }
            return node;
        }

        // Definition for a QuadTree node.
        public class Node
        {
            public bool val;
            public bool isLeaf;
            public Node topLeft;
            public Node topRight;
            public Node bottomLeft;
            public Node bottomRight;

            public Node() { }
            public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = _topLeft;
                topRight = _topRight;
                bottomLeft = _bottomLeft;
                bottomRight = _bottomRight;
            }
        }
    }
}
