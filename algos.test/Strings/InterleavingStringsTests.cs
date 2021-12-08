using System;
using algos.Strings;
using Xunit;


public class InterleavingStringsTests
{
    [Theory]
    [InlineData("a", "b", "ab", true)]
    [InlineData("a", "b", "ba", true)]
    [InlineData("", "b", "b", true)]
    [InlineData("a", "", "a", true)]
    [InlineData("aabcc", "dbbca", "aadbbcbcac", true)]
    [InlineData("aabcc", "dbbca", "aadbbbaccc", false)]
    [InlineData("", "", "", true)]

    public void Validate(string a, string b, string c, bool expected){
        var sol = new InterleavingStrings();
        Assert.Equal(expected, sol.IsInterleave(a,b, c));
        

    }

}
