using System;
using System.Linq;
using System.Collections.Generic;

namespace algos.Recursion
{
    public class SolutionRemoveParens
    {


        public IList<string> RemoveInvalidParentheses(string s)
        {
            minCount = int.MaxValue;
            result = new HashSet<string>();
            RemoveInvalidParentheses(s, 0, 0, 0, "");
            return result.ToList();
        }

        private int minCount = int.MaxValue;
        private HashSet<string> result = new HashSet<string>();
        private HashSet<string> memo = new HashSet<string>();

        public void RemoveInvalidParentheses(string s,
                                             int currentIndex,
                                             int removedCount,
                                             int openParenCount,
                                             string prefix)
        {
            if (currentIndex >= s.Length)
            {
                if (openParenCount == 0 && removedCount <= minCount)
                {
                    if (removedCount < minCount)
                    {
                        result.Clear();
                    }

                    result.Add(prefix);

                    minCount = removedCount;
                }

                return;
            }

            var key = $"{currentIndex}-{removedCount}-{openParenCount}-{prefix}";
            if (memo.Contains(key))
            {
                return;
            }

            memo.Add(key);

            if (s[currentIndex] != '(' && s[currentIndex] != ')')
            {
                RemoveInvalidParentheses(s,
                                         currentIndex + 1,
                                         removedCount,
                                         openParenCount,
                                         prefix += s[currentIndex]);
                return;
            }

            if (s[currentIndex] == ')' && openParenCount < 1)
            {

                RemoveInvalidParentheses(s,
                                         currentIndex + 1,
                                         removedCount + 1,
                                         openParenCount,
                                         prefix);
                return;

            }

            RemoveInvalidParentheses(s,
                                         currentIndex + 1,
                                         removedCount + 1,
                                         openParenCount,
                                         prefix);


            RemoveInvalidParentheses(s,
                                     currentIndex + 1,
                                     removedCount,
                                     s[currentIndex] == '(' ? openParenCount + 1 : openParenCount - 1,
                                     prefix += s[currentIndex]);

        }

    }

}