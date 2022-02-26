using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Strings
{
    public class ParensGenerator
    {
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new HashSet<string>();
            GenerateParensInternal(n, result, "", 0, 0, new HashSet<string>());
            return new List<string>(result);
        }

        private void GenerateParensInternal(int num, HashSet<string> result, string prefix, int leftAddedCount, int rightAddedCount, HashSet<string> memo)
        {

            if(leftAddedCount == num && rightAddedCount == num)
            {
                result.Add(prefix);
                return;
            }

            if (memo.Contains(prefix))
            {
                return;
            }

            memo.Add(prefix);

            if(leftAddedCount == num)
            {
                GenerateParensInternal(num, result, prefix + ')', leftAddedCount, rightAddedCount + 1, memo);
                return;
            }
            
            if(leftAddedCount == rightAddedCount)
            {
                GenerateParensInternal(num, result, prefix + '(', leftAddedCount + 1, rightAddedCount, memo);
                return;

            }

            GenerateParensInternal(num, result, prefix + '(', leftAddedCount + 1, rightAddedCount, memo);
            GenerateParensInternal(num, result, prefix + ')', leftAddedCount, rightAddedCount + 1, memo);

        }
    }
}
