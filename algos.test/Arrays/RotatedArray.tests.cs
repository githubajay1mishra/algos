using algos.Arrays;
using Xunit;

namespace algos.test.Arrays
{
    public class RoatatedtArrayTests
    {
        [Theory]
        [InlineData(new int[]{3 ,1}, 3, 0)]
        public void ValidatedRotatedtArray(int[] nums, int target, int expected){
            var sol = new RotatedArray();
            var actual = sol.Search(nums, target);
            Assert.Equal(expected, actual);
        }
    }
}
