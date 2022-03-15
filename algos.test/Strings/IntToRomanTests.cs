using algos.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace algos.test.Strings
{
    public class IntToRomanTests
    {
        [Theory]
        [InlineData(3, "III")]
        [InlineData(58, "LVIII")]
        [InlineData(1994, "MCMXCIV")]
        public void Validate(int num, string roman)
        {
            var sol = new RomanNumeralStringToAlgo();
            Assert.Equal(roman, sol.IntToRoman(num));
        }

    }
}
