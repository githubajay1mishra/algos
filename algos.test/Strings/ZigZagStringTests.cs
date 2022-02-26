using Xunit;
using algos.Strings;
public class ZigZagStringTests{

    [Theory]
    [InlineData("aa", 1, "aa")]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]

    public void ValidateSimplifyPaths(string input, int rows, string expected){
        var sol = new ZigZagString();
        Assert.Equal(expected, sol.Convert(input, rows));

    }

}