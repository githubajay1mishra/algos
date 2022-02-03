using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algos.Dynamic_Programming
{
    public class LongestSubsequenceInDictionary
    {
        public int Solve(string input, string[] words)
        {
            var result = 0;
            Dictionary<string, bool> memo = new Dictionary<string, bool>();

            foreach (var word in words)
            {
                memo[word] = memo.ContainsKey(word) ? memo[word] : IsSubsequence(input, word, 0, 0);

                if(memo[word])
                {
                    result = Math.Max(result, word.Length);

                }
            }
            return result;
        }

        public bool IsSubsequence(string input, string word, int inputIndex, int wordIndex)
        {
            if (inputIndex <= input.Length && wordIndex == word.Length) return true;

            if (inputIndex == input.Length || wordIndex == word.Length) return false;

            if(input[inputIndex] == word[wordIndex])
            {
                return IsSubsequence(input, word, inputIndex + 1, wordIndex + 1);
            }

            return IsSubsequence(input, word, inputIndex + 1, wordIndex);

        }

       
    }
}
