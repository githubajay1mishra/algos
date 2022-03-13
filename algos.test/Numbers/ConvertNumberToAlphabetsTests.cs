using System;
using Xunit;
using Xunit.Abstractions;
using algos.Numbers;

namespace algos.test.Numbers
{
    public partial class ConvertNumberToAlphabetsTests : MakeConsoleWork
    {

        private ITestOutputHelper OutputHelper { get; }

        public ConvertNumberToAlphabetsTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
            OutputHelper = outputHelper;

        }

        [Theory]
        [InlineData(1, "A")]
        [InlineData(2, "B")]
        [InlineData(26, "Z")]
        [InlineData(27, "AA")]
        [InlineData(28, "AB")]
        [InlineData(52, "AZ")]
        public void Validate(int number, string expected)
        {
            var sol = new ConvertNumberToAlphabets();
            Assert.Equal(expected, sol.ConvertToBase26String(number));

        }

        [Fact]
        public void ValidateAll()
        {
            var sol = new ConvertNumberToAlphabets();
            for (int i = 1; i < 10000; i++)
            {
                Console.WriteLine($"{i} - {sol.ConvertToBase26String(i)}");
            }

        }


    }
}
