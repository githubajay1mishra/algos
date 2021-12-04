using algos.Arrays;
using Xunit;

public class NextPermutationTests{

    [Theory]
    [InlineData(new int[]{1,2,3}, new int[]{1,3,2})]
    [InlineData(new int[]{1,3,5,5,4,4}, new int[]{1,4,3,4,5,5})]

    public void CheckNextPermutation(int[] nums, int[] expected){
        var sol = new NextPermutation();
        sol.FindNextPermutation(nums);
        Assert.Equal(nums, expected);

    }

}