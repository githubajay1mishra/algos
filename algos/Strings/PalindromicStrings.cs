using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Strings
{
    public class PalindromicStrings
    {
        public bool IsPalindromic(int number)
        {
            if (number < 0)
            {
                return false;
            }

            var digits = new List<int>();
            while (number > 9)
            {
                var digit = number % 10;
                number = number / 10;
                digits.Add(digit);
            }

            digits.Add(number);
            digits.Reverse();


            var start = 0;
            var end = digits.Count - 1;
            while (start < end)
            {
                if (digits[start] != digits[end]) return false;
                start++;
                end--;
            }

            return true;
        }
    }
}
