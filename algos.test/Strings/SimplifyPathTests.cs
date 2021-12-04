using Xunit;

public class SimplifyPathTest{

    [Theory]
    [InlineData("/home/", "/home")]
    [InlineData("/../", "/")]
    [InlineData("/home//foo", "/home/foo")]
    [InlineData("/a/./b/../../c/", "/c")]
    [InlineData("/a/b/../../b/", "/b")]

    public void ValidateSimplifyPaths(string unixPath, string expectedCanonicalPath){
        var sol = new StringPathBuilder();
        Assert.Equal(expectedCanonicalPath, sol.ToCanonicalPath(unixPath));

    }
}