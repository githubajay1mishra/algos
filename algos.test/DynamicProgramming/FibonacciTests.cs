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

        [Fact]
        public void MinimumJumpsToEnd(){
            Assert.Equal(3, new FibonacciNumbers().MinimumJumpsToEnd(new int[]{2,1,1,1,4}));
            Assert.Equal(4, new FibonacciNumbers().MinimumJumpsToEnd(new int[]{1,1,3,6,9,3,0,1,3}));

        }

        [Fact]
        public void MinimumJumpsWithFee(){
            Assert.Equal(3, new FibonacciNumbers().MinimumJumpsToEndWithFee(new int[]{1,2,5,2,1,2}));
            Assert.Equal(5, new FibonacciNumbers().MinimumJumpsToEndWithFee(new int[]{2,3,4,5}));

        }
    }
}
