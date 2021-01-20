using algos.DynamicProgramming;
using Xunit;
namespace algos.test.DynamicProgramming
{
    public class FibonacciTests
    {
        [Fact]
        public void CountWayStairCase()
        {
            Assert.Equal(4, new FibonacciNumbers().CountWaysToTop(3));
            Assert.Equal(7, new FibonacciNumbers().CountWaysToTop(4));
        }

        [Fact]
        public void CountWaysOfSums()
        {
            Assert.Equal(4, new FibonacciNumbers().CountWaysToSum(4));
            Assert.Equal(6, new FibonacciNumbers().CountWaysToSum(5));
        }

        [Fact]
        public void HouseThief(){
            Assert.Equal(15, new FibonacciNumbers().HouseThief(new int[]{2, 5, 1, 3, 6, 2, 4}));
            Assert.Equal(18, new FibonacciNumbers().HouseThief(new int[]{2, 10, 14, 8, 1}));

        }
    }
}
