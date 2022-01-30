using System;
using System.Collections.Generic;
using System.Text;
using algos.BackTracking;
using Xunit;

namespace algos.test.BackTracking
{
    public class CombinationSumOneTests
    {
        private readonly CombinationSumOne sol;
        public CombinationSumOneTests()
        {
            sol = new CombinationSumOne();
        }

        [Fact]
        public void ValidateExample1()
        {
            var result = sol.CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
            var expected = new List<List<int>>
            {
                new List<int> { 2, 2, 3 },
                new List<int> { 7 }
            };
            Assert.Equal(expected, result);

        }

    
    }
}
