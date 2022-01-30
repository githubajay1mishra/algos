using System;
using System.Collections.Generic;
using System.Text;
using algos.BackTracking;
using Xunit;

namespace algos.test.BackTracking
{
    public class CombinationSumThreeTests
    {
        private readonly CombinationSumThree sol;
        public CombinationSumThreeTests()
        {
            sol = new CombinationSumThree();
        }

        [Fact]
        public void ValidateExample1()
        {
            var result = sol.CombinationSum3(3, 7);
            var expected = new List<List<int>>
            {
                new List<int> { 1, 2, 4}
            };
            Assert.Equal(expected, result);

        }

        [Fact]
        public void ValidateExample2()
        {
            var result = sol.CombinationSum3(3, 9);
            var expected = new List<List<int>>
            {
                new List<int> { 1,2,6},
                new List<int> {1,3,5},
                new List<int> {2,3,4},
                            
            };
            Assert.Equal(expected, result);

        }
    }
}
