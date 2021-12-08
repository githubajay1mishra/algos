using System;
using System.Collections.Generic;

namespace algos.Strings
{
    public class InterleavingStrings
    {
        public bool IsInterleave(string a, string b, string c)
        {
            if (a.Length + b.Length != c.Length)
            {
                return false;
            }
            return IsInterleave(a, b, c, 0, 0, 0, new Dictionary<string, bool>());
        }

        public bool IsInterleave(string a, string b, string c, int aPos, int bPos, int cPos, Dictionary<string, bool> memo)
        {


            if (cPos == c.Length)
            {
                return aPos == a.Length && bPos == b.Length;
            }

            var key = $"{aPos}-{bPos}";

            if (memo.ContainsKey(key))
            {
                return memo[key];
            }


            memo[key] = false;


            if (aPos < a.Length && a[aPos] == c[cPos])
            {

                var resultA = IsInterleave(a, b, c, aPos + 1, bPos, cPos + 1, memo);
                memo[key] = resultA;
                if (resultA)
                {
                    return memo[key];
                }
            }

            if (bPos < b.Length && b[bPos] == c[cPos])
            {

                var resultB = IsInterleave(a, b, c, aPos, bPos + 1, cPos + 1, memo);
                memo[key] = resultB;


            }



            return memo[key];
        }
    }
}
