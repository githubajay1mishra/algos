using algos.Stacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace algos.test.Stack
{
    public class LargestAreaHistogramTests
    {
        [Theory]
        [InlineData(new int[] {2, 1, 5, 6, 2, 3 }, 10)]
        [InlineData(new int[] { 1, 1 }, 2)]
        [InlineData(new int[] { 2, 1, 2 }, 3)]
        [InlineData(new int[] { 2, 0, 1, 2 }, 2)]
        [InlineData(new int[] { 5, 4, 1, 2 }, 8)]
        [InlineData(new int[] { 5, 4, 4, 6, 3, 2, 9, 5, 4, 8, 1, 0, 0, 4, 7, 2 }, 20)]
        public void Validate(int[] nums, int expected)
        {
            Assert.Equal(expected, new LargestAreaHistogram().LargestRectangleArea(nums));
        }
    }
}
