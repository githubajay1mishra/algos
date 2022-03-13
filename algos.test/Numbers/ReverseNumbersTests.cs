using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using algos.Numbers;

namespace algos.test.Numbers
{
    public class ReverseNumbersTests:MakeConsoleWork
    {
        public ReverseNumbersTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(123, 321)]
        [InlineData(0, 0)]
        [InlineData(-321, -123)]
        [InlineData(-62, -26)]
        [InlineData(int.MinValue, 0)]
        [InlineData(int.MaxValue, 0)]
        [InlineData(1534236469, 0)]

        public void Validate(int original, int reversed)
        {

            var maxIntValueUnsigned = Math.Abs((uint)int.MaxValue);
            var minIntValueUnsigned = maxIntValueUnsigned + 1;
            Assert.Equal(reversed, new ReverseNumber().Reverse(original));


        }
    }
}
