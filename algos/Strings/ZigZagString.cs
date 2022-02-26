using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algos.Strings
{
    public class ZigZagString
    {
        public string Convert(string s, int numRows)
        {
            var sb = new StringBuilder[numRows];
            for (int i = 0; i < numRows; i++)
            {
                sb[i] = new StringBuilder();
            }
            var charIndex = 0;
            while(charIndex < s.Length)
            {
                for (int i = 0; i < numRows && charIndex < s.Length; i++)
                {

                    sb[i].Append(s[charIndex]);
                    charIndex++;


                }

                for(int index = numRows - 2; index > 0 && charIndex < s.Length; index--)
                {
                    sb[index].Append(s[charIndex]);
                    charIndex++;
                }


            }
            
            return String.Join("", sb.Select(s => s.ToString()));
        }
    }
}
