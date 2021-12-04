using System;
using System.Linq;

namespace algos.Strings
{
    public class LongestCommonPrefixSol
    {
         public string LongestCommonPrefix(string[] strs) {
            var minLength = strs.Select(x => x.Length).Max();
            int commonIndex =  0;
            for(int index = 0; index < minLength; index++){
                var matches = strs.All( x => x[index] == strs[0][index]);
                if(!matches){
                    break;
                }
                commonIndex++;
            }

            if(commonIndex > 0){
                return strs[0].Substring(0, commonIndex);
            }
            return "";
         } 
    }
}
