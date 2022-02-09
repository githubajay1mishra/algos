using System.Linq;
using System.Collections.Generic;
using System;
using Xunit;
using algos.Permutations;

namespace algos.test.Permutations
{
    public class CountUniquePermuationsTests
    {

        [Theory]
        [InlineData(new int[] { 3, 1, 1, 1 }, 2)]
        [InlineData(new int[] { 3, 1, 1, 3 }, 1)]
        [InlineData(new int[] { 1, 1, 1, 1 }, 0)]

        public void CheckNextPermutation(int[] nums, int expected)
        {
            var sol = new CountUniquePermuations();
            Assert.Equal(expected, sol.CountPermutations(nums));

        }


    }



}