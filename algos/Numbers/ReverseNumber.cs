using System;
using System.Collections.Generic;
using System.Text;

namespace algos.Numbers
{
    public class ReverseNumber
    {
        public int Reverse(int input)
        {

            const int INT_MAX_DIV_10 = int.MaxValue / 10;

            bool isNegative = input < 0;
            var remainingNumber = input;
            var reversed = 0;


            while (remainingNumber != 0)
            {
                
                var lastDigit = Math.Abs( remainingNumber % 10);
                

                if(reversed > INT_MAX_DIV_10 || 
                   (isNegative && reversed == INT_MAX_DIV_10  && lastDigit > 8)
                   ||
                   (reversed == INT_MAX_DIV_10 && lastDigit > 7)
                   )
                {
                    return 0;
                }

                remainingNumber = remainingNumber / 10;
                reversed = (reversed * 10) + lastDigit;
            }

            return isNegative ? -1 * reversed : reversed;


        }
    }
}
