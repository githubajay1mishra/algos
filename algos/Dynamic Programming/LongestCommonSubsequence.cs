using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Dynamic_Programming
{
    public class LongestCommonSubsequence
    {
        public int Solve(string text1, string text2)
        {
            return Solve(text1, text2, 0 , 0,  new Dictionary<(int current1, int current2), int>());
        }

        public int Solve(string text1, string text2, int current1, int current2, Dictionary<(int current1, int current2), int> memo)
        {
            if (current1 >= text1.Length || current2 >= text2.Length) return 0;

            if(memo.ContainsKey((current1, current2)))
            {
                return memo[(current1, current2)];
            }

            if(text1[current1] == text2[current2])
            {
                memo[(current1, current2)] = 1 + Solve(text1, text2, current1 + 1, current2 + 1, memo);
            }
            else
            {
                var result1 = Solve(text1, text2, current1 + 1, current2, memo);
                var result2 = Solve(text1, text2, current1, current2 + 1, memo);
                memo[(current1, current2)] = Math.Max(result2, result1);
            }

            return memo[(current1, current2)];

        }
        
    }
}
