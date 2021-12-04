using algos.Arrays;
using Xunit;

namespace algos.test.Arrays
{
    public class LongestValidParentTests
    {
        [Theory]
        [InlineData("()", 2)]
        [InlineData(")()", 2)]
        public void ValidateLongestParenthesisLength(string input, int expected){
            var sol = new LongestValidParenthesis();
            var length = sol.GetLongestValidParenthesisLength(input);
            Assert.Equal(expected, length);
        }
    }
}
