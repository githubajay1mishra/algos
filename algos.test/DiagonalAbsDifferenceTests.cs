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

        
    }
}
