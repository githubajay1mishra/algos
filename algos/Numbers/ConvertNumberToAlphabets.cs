using System;

namespace algos.Numbers
{
    public class ConvertNumberToAlphabets
    {
        char[] charArray = new char[26];
        public ConvertNumberToAlphabets()
        {
            charArray[0] = 'Z';
            for (int i = 0; i < 25; i++)
            {
                char c = 'A';
                charArray[i + 1] = Convert.ToChar(c + i);

            }
        }
        public string ConvertToBase26String(int number)
        {
            var result = "";
            var numberForConversion = number;
            while (numberForConversion > 26)
            {
                result = ToStringValue(numberForConversion % 26) + result;
                numberForConversion = numberForConversion % 26 == 0 ? numberForConversion / 26 - 1 : numberForConversion / 26;
            }

            result = ToStringValue(numberForConversion % 26).ToString() + result;


            return result;

        }

        private char ToStringValue(int v)
        {
            return charArray[v];
        }

    }
}
