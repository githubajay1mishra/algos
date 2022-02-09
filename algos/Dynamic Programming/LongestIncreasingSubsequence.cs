using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace algos.Dynamic_Programming
{
    public class LongestIncreasingSubsequence
    {
        private int _count;

        public LongestIncreasingSubsequence()
        {
        }
        public int LengthOfLIS(int[] nums)
        {
            var dp = new int[nums.Length];
            Array.Fill(dp, 1);

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    this._count++;
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], 1 + dp[j]);
                    }
                }
            }


            return dp.Max();

            



        }

        public int LengthOfLIS(int[] nums, int current, int previous, Dictionary<string, int> memo)
        {
            if (current >= nums.Length)
            {
                return 0;
            }
            this._count++;

            var previousValue = previous == - 1 ? int.MinValue : nums[previous];

            var currentValue = nums[current];
            var key = $"{current}-{previous}";
            
            if(memo.ContainsKey(key))
            {
                return memo[key];

            }
            if(currentValue > previousValue)
            {
                memo[key] = Math.Max(1 + LengthOfLIS(nums, current + 1, current, memo), LengthOfLIS(nums, current + 1, previous, memo));

            }
            else
            {
                memo[key] = LengthOfLIS(nums, current + 1, previous, memo);

            }

            return memo[key];
        }

    }
}
