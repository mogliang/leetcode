using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.g
{
    public class _950
    {
        public int[] DeckRevealedIncreasing(int[] deck)
        {
            Array.Sort(deck);
            var result = new int[deck.Length];


            var q = new Queue<int>();
            for (int i = 0; i < deck.Length; i++) q.Enqueue(i);

            int count = 0;
            int idx = 0;
            while (q.Count > 0)
            {
                if (count % 2 == 0)
                {
                    result[q.Dequeue()] = deck[idx];
                    idx++;
                }
                else
                {
                    q.Enqueue(q.Dequeue());
                }
                count++;
            }
            return result;
        }
    }
}
