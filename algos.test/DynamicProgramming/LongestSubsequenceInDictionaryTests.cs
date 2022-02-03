using algos.Dynamic_Programming;
using Xunit;

namespace algos.test.DynamicProgramming
{
    public class LongestSubsequenceInDictionaryTests
    {

        [Theory]
        [InlineData("abcde", new string[] { "a", "bb", "acd", "ace" }, 3)]
        [InlineData("dsahjpjauf", new string[] { "ahjpjau", "ja", "ahbwzgqnuk", "tnmlanowax" }, 7)]
        public void Validate(string text1, string[] words, int expectedLength)
        {
            var sut = new LongestSubsequenceInDictionary();
            var result = sut.Solve(text1, words);
            Assert.Equal(expectedLength, result);

        }


    }
}
