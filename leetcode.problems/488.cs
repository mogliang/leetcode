using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace leetcode.problems
{
    /// <summary>
    /// https://leetcode.com/problems/zuma-game/
    /// </summary>
    [TestClass]
    public class _488
    {
        [TestMethod]
        public void FindMinStepTest()
        {
            Assert.AreEqual("", CheckShoot("aabbccdddcbba", 6));
            Assert.AreEqual("", CheckShoot("aabbccdddcbba", 7));
            Assert.AreEqual("", CheckShoot("aabbccdddcbba", 8));
            Assert.AreEqual("aabbccddcbba", CheckShoot("aabbccddcbba", 8));

            //var result = FindMinStep("aabbccddcbba", "abcd");
            var result2 = FindMinStep("aabbcddeeff", "fedccba");
        }

        public int FindMinStep(string board, string hand)
        {
            if (board == string.Empty) return 0;
            int min = int.MaxValue;
            for(int i = 0; i < board.Length; i++)
            {
                for(int j = 0; j < hand.Length; j++)
                {
                    if (board[i] == hand[j] && (i==0 || board[i-1]!=board[i]))
                    {
                        var newBoard = board.Substring(0, i) + hand[j] + board.Substring(i);
                        newBoard = CheckShoot(newBoard, i);

                        var cur = 1 + FindMinStep(newBoard, hand.Substring(0, j) + (j == hand.Length - 1 ? "" : hand.Substring(j + 1)));
                        if (cur > 0 && cur < min)
                            min = cur;
                    }
                }
            }
            return min == int.MaxValue ? -1 : min;
        }

        string CheckShoot(string board, int idx)
        {
            if (idx < 0 || idx >= board.Length) return board;

            var c = board[idx];
            var start = idx;
            var count = 1;
            if (idx > 0 && board[idx - 1] == c)
            {
                if(idx>1 && board[idx - 2] == c)
                {
                    count += 2;
                    start -= 2;
                }
                else
                {
                    count += 1;
                    start -= 1;
                }
            }
            if (idx < board.Length - 1 && board[idx+1]==c)
            {
                if(idx<board.Length-2 && board[idx + 2] == c)
                {
                    count += 2;
                }
                else
                {
                    count += 1;
                }
            }

            if (count >= 3)
            {
                board = board.Substring(0, start) + board.Substring(start + count);
                return CheckShoot(board, start);
            }
            else
            {
                return board;
            }
        }
    }
}
