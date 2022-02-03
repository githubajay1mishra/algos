using algos.Dynamic_Programming;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace algos.test.DynamicProgramming
{
    public class LongestCommonSubsequenceTests
    {
        [Theory]
        [InlineData("abcde", "ace", 3)]
        public void Validate(string text1, string text2, int expectedLength)
        {
            var sut = new LongestCommonSubsequence();
            var result = sut.Solve(text1, text2);
            Assert.Equal(expectedLength, result);

        }

    }
}
