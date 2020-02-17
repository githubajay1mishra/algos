using System;
using System.Collections.Generic;
using System.Linq;

namespace algos.Arrays
{
    public class OneEditDistanceSolution
    {
        public bool IsOneEditDistance(string s, string t)
        {
            if(s.Length > t.Length){
                return IsOneEditDistance(t, s);
            }

            if(t.Length - s.Length > 1){
                return false;
            }

            for(int index  = 0; index < s.Length; index++){
                if(s[index] != t[index]){
                    if(s.Length == t.Length){
                        return s.Substring(index + 1).Equals(t.Substring(index + 1));
                    }

                    return s.Substring(index).Equals(t.Substring(index + 1));
                }
            }

            return s.Length + 1 == t.Length;
        }
    }

}