using System;
using System.Collections.Generic;
using System.Linq;

namespace algos.DynamicProgrammng
{
    public class WordBreakSolution
    {

        public bool WordBreak(string s, IList<string> wordDict)
        {
            var wordList = new HashSet<string>();

            var memo = new Dictionary<int, bool>();

            foreach (var entry in wordDict)
            {
                wordList.Add(entry);
            }

            return WordBreak(s, 0, wordList, memo);
        }

        public bool WordBreak(string s, int index, HashSet<string> wordList, Dictionary<int, bool> memo)
        {
            if (index >= s.Length)
            {
                return true;
            }

            if (memo.ContainsKey(index))
            {

                return memo[index];

            }


            int end = index;
            memo[index] = false;
            while (end < s.Length)
            {
                var prefix = s.Substring(index, end - index + 1);

                if (wordList.Contains(prefix))
                {
                    var remainingContainsWords = WordBreak(s, end + 1, wordList, memo);

                    if (remainingContainsWords)
                    {
                        memo[index] = true;
                        break;
                    }
                }

                end++;
            }

            return memo[index];
        }
    }

}