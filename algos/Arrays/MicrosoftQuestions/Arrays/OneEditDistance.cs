using System;
using System.Collections.Generic;
using System.Linq;

namespace algos.Arrays
{
    public class OneEditDistanceSolution
    {
        public bool IsOneEditDistance(string s, string t)
        {
            var frequency = new Dictionary<char, int>();

            foreach(var charFromS in s){

                frequency[charFromS] = frequency.ContainsKey(charFromS) ? frequency[charFromS] + 1
                : 1;
            }

            foreach(var charFromT in t){

                frequency[charFromT] = frequency.ContainsKey(charFromT) ? frequency[charFromT] - 1
                : -1;
            }

            int diff = 0;
            foreach(var value in frequency.Values){
                if(value != 0){
                    diff++;
                }               
            }

            return diff == 1 ? true : false;

        }
    }

}