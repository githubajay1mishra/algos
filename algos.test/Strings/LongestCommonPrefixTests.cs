using System;
using Xunit;
using algos.Strings;

namespace algos.test.Strings
{
    public class LongestCommonPrefixTests
    {
        [Theory]
        [InlineData(new string[]{"florida", "flow", "flag"}, "fl")]
        public void ValidatePrefix(string[] strings, string expectedprefix){

           var sol = new LongestCommonPrefixSol();
           Assert.Equal(expectedprefix, sol.LongestCommonPrefix(strings));
           
        }
    }
}
