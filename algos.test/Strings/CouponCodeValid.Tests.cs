using Xunit;
using algos.Strings;
public class ValidateCouponsTests{

    [Theory]
    [InlineData("aa", true)]
    [InlineData("aabb", true)]
    [InlineData("bab", false)]
    [InlineData("b", false)]
    [InlineData("abba", true)]
    [InlineData("caabbc", true)]

    public void ValidateSimplifyPaths(string coupon, bool isValid){
        var sol = new ValidateCoupons();
        Assert.Equal(isValid, sol.isValidCoupon(coupon));

    }

}