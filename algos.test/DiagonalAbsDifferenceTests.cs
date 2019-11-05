using System;
using Xunit;

namespace algos.test
{
    public class DiagonalDifferenceTests
    {
        private readonly DiagonalAbsDifference _calcDifference;


        public DiagonalDifferenceTests()
        {
            _calcDifference = new DiagonalAbsDifference();

        }
        [Fact]
        public void DimensionalArrayMustBe0()
        {
            var output = _calcDifference.CalculateDifference(new int[1,1]{ {0}}, 1);
            Assert.Equal(0, output);
        }

        [Fact]
        public void DimensionalArrayMustBe2()
        {
            var output = _calcDifference.CalculateDifference(new int[2,2]{ {2, 1}, {1, 2}}, 2);
            Assert.Equal(2, output);
        }
    }
}
