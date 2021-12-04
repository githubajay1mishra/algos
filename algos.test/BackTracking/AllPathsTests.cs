using System;
using System.Collections.Generic;
using Xunit;

namespace algos.test.BackTracking
{
    public class AllPathsTests
    {
        [Fact]
        public void TestPaths(){
            var allPaths = new AllPaths();
            var results = allPaths.AllPathsSourceTarget(new int[][]{
                new int[]{1,2},
                new int[] {3},
                new int [] {3},
                new int[]{}
            });
            Assert.Equal(new List<IList<int>>{
                new List<int>{0, 1, 3},
                new List<int>{0, 2, 3},
            }, results);
        }
    }
}
