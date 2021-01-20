using algos.DynamicProgramming;
using Xunit;
public class SubsetSumTests{

    [Theory]
    [InlineData(new[]{1, 2, 3, 7}, 6, true)]
    public void ValidateAlgo(int[] nums, int sum, bool expected){
        var subsetSum = new SubsetSum();
        Assert.Equal(expected, subsetSum.TopDownSubSetSum(nums, sum));

    }

    [Fact]
    public void UnboundedKnapsackTopDown(){
        var weights = new int[]{1,2,3};
        var profits = new int[]{15, 20,50};
        var capacity = 5;
        Assert.Equal(80, new UnboundedKnapsack().TopDown(weights, profits, capacity));

    }

     [Fact]
    public void UnboundedKnapsackRodCutBottomUp(){
        var lengths = new int[]{1, 2, 3, 4, 5};
        var profits = new int[]{2, 6, 7, 10, 13};
        var length = 5;
        Assert.Equal(14, new UnboundedKnapsack().CutRodBottomUp(length, lengths, profits));

    }

    [Fact]
    public void UnboundedKnapsackTotalCoinChange(){
        var coins = new int[]{1,2,3};
        var total = 5;
        Assert.Equal(5, new UnboundedKnapsack().CoinChangeTopDown(coins, total));
    }

    [Fact]
    public void UnboundedKnapsackMinimumCoinChange()
    {
        Assert.Equal(2, new UnboundedKnapsack().MinimumCoinChangeTopDown(new int[]{1,2,3}, 5));
        Assert.Equal(4, new UnboundedKnapsack().MinimumCoinChangeTopDown(new int[]{1,2,3}, 11));
    
    }

    [Fact]
     public void UnboundedKnapsackMaxRodCut()
    {
        Assert.Equal(2, new UnboundedKnapsack().MaximumRodCut(new int[]{2,3,5}, 5));
        Assert.Equal(3, new UnboundedKnapsack().MaximumRodCut(new int[]{2,3}, 7));
    
    }


}