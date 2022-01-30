using Xunit;
using algos.Strings;
public class DetectCapitalsTest{

    [Theory]
    [InlineData("USA", true)]
    [InlineData("leetcode", true)]
    [InlineData("Google", true)]
    [InlineData("bG", false)]
    [InlineData("", true)]    

    public void Validate(string coupon, bool isValid){
        var sol = new DetectCapitals();
        Assert.Equal(isValid, sol.DetectCapitalUse(coupon));

    }

    

}