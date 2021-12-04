using System;
using System.Collections.Generic;
using algos.BackTracking;
using Xunit;

namespace algos.test.BackTracking
{
    public class BackTrackingTests
    {
        [Fact]
        public void TestName()
        {
            var solution = new NumberPermutations();
            var results = solution.PermuteUnique(new int[]{1, 1, 2});
            Assert.Equal(results, new List<IList<int>>(){
                new List<int>() {1,1,2},
                new List<int>() {1,2, 1},
                new List<int>() {2, 1,1},
            });
        }
    }
}
