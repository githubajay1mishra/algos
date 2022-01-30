using System;
using System.Collections.Generic;
using System.Text;
using algos.BackTracking;
using Xunit;

namespace algos.test.BackTracking
{
    public class CombinationSumTwoTests
    {
        private readonly CombinationSumTwo sol;
        public CombinationSumTwoTests()
        {
            sol = new CombinationSumTwo();
        }

        [Fact]
        public void ValidateExample1()
        {
            var result = sol.CombinationSum(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
            var expected = new List<List<int>>
            {
                new List<int> { 1,1,6 },
                new List<int> { 1,2,5 },
                new List<int> { 1, 7 },
                new List<int> { 2,6 },
            };
            Assert.Equal(expected, result);

        }

        [Fact]
        public void ValidateExample2()
        {
            var result = sol.CombinationSum(new int[] { 2, 5, 2, 1, 2 }, 5);
            var expected = new List<List<int>>
            {
                new List<int> { 1,2,2 },
                new List<int> { 5 },
            };
            Assert.Equal(expected, result);

        }

        [Fact]
        public void ValidateExample3()
        {
            var result = sol.CombinationSum(new int[] { 1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 30);
            var expected = new List<List<int>>
            {
                new List<int> { 1,1,1,1,1,1,1,1,1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };
            Assert.Equal(expected, result);

        }


    }
}
