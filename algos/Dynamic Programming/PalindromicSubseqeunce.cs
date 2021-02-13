using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace algos.DynamicProgramming
{
    public class PalindromicSubsequence
    {
        public int LongestPalindromicSubsequence(string input)
        {
            return LongestPalindromicSubsequence(input, 0, input.Length - 1, new Dictionary<string, int>());
        }

        public int LongestPalindromicSubsequence(string input, int startIndex, int endIndex, Dictionary<string, int> cache)
        {
            if (endIndex < startIndex)
            {
                return 0;
            }
            if (startIndex == endIndex)
            {
                return 1;
            }

            var key = $"{startIndex}-{endIndex}";
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            if (input[startIndex] == input[endIndex])
            {
                cache[key] = 2 + LongestPalindromicSubsequence(input, startIndex + 1, endIndex - 1, cache);

            }
            else
            {
                cache[key] = Math.Max(LongestPalindromicSubsequence(input, startIndex + 1, endIndex, cache),
                    LongestPalindromicSubsequence(input, startIndex, endIndex - 1, cache));

            }


            return cache[key];
        }

        public int CountPalindromicSubstrings(string input)
        {
            int count = input.Length;
            CountPalindromicSubstrings(input, 0, input.Length - 1, new Dictionary<string, bool>(), ref count);
            return count;
        }

        public int MinimumDeletionToFormPalindrominString(string input)
        {
            return input.Length - LongestPalindromicSubsequence(input, 0, input.Length  - 1, new Dictionary<string, int> ());
        }

        

        public bool CountPalindromicSubstrings(string input, int startIndex, int endIndex, Dictionary<string, bool> cache, ref int count)
        {
            if (startIndex > endIndex)
            {
                return true;
            }

            if (startIndex == endIndex)
            {
                return true;
            }

           


            var key = $"{startIndex}-{endIndex}";
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }



            cache[key] = false;

            if (CountPalindromicSubstrings(input, startIndex + 1, endIndex - 1, cache, ref count))
            {
                if (input[startIndex] == input[endIndex])
                {
                    cache[key] = true;
                    count++;

                }

            }

            CountPalindromicSubstrings(input, startIndex + 1, endIndex, cache, ref count);
            CountPalindromicSubstrings(input, startIndex, endIndex - 1, cache, ref count);


            return cache[key];

        }


        public int LongestPalindromicSubstring(string input)
        {
            return LongestPalindromicSubstring(input, 0, input.Length - 1, new Dictionary<string, int>());
        }

        public int LongestPalindromicSubstring(string input, int startIndex, int endIndex, Dictionary<string, int> cache)
        {
            if (endIndex < startIndex)
            {
                return 0;
            }

            if (endIndex == startIndex) return 1;

            var key = $"{startIndex}-{endIndex}";
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            if (input[startIndex] == input[endIndex])
            {
                var remainingLength = endIndex - startIndex + 1 - 2;
                if (remainingLength == LongestPalindromicSubstring(input, startIndex + 1, endIndex - 1, cache))
                {
                    cache[key] = remainingLength + 2;
                    return cache[key];
                }
            }

            var pl1 = LongestPalindromicSubstring(input, startIndex + 1, endIndex, cache);
            var pl2 = LongestPalindromicSubstring(input, startIndex, endIndex - 1, cache);
            cache[key] = Math.Max(pl1, pl2);
            return cache[key];
        }

    }

}