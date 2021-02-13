using System;
using Xunit;
using algos.DynamicProgramming;

namespace algos.test.DynamicProgramming
{

    public class PalindromicSubsequenceTests
    {

        [Fact]
        public void ValidateLongestPalindromicSubsequence()
        {
            Assert.Equal(5, new PalindromicSubsequence().LongestPalindromicSubsequence("abdbca"));
            Assert.Equal(3, new PalindromicSubsequence().LongestPalindromicSubsequence("ddd"));
            Assert.Equal(1, new PalindromicSubsequence().LongestPalindromicSubsequence("pqr"));


        }

         [Fact]
        public void ValidateLongestPalindromicSubstring()
        {
            Assert.Equal(3, new PalindromicSubsequence().LongestPalindromicSubstring("abdbca"));
            Assert.Equal(3, new PalindromicSubsequence().LongestPalindromicSubstring("cddpd"));
            Assert.Equal(1, new PalindromicSubsequence().LongestPalindromicSubstring("pqr"));


        }

         [Fact]
        public void ValidateCountPalindromicSubstrings()
        {
            Assert.Equal(7, new PalindromicSubsequence().CountPalindromicSubstrings("abdbca"));
            Assert.Equal(7, new PalindromicSubsequence().CountPalindromicSubstrings("cddpd"));
            Assert.Equal(3, new PalindromicSubsequence().CountPalindromicSubstrings("pqr"));
        }

         [Fact]
        public void ValidateMinimumDeletionsToFormPalindromicString()
        {
            Assert.Equal(1, new PalindromicSubsequence().MinimumDeletionToFormPalindrominString("abdbca"));
            Assert.Equal(2, new PalindromicSubsequence().MinimumDeletionToFormPalindrominString("cddpd"));
            Assert.Equal(2, new PalindromicSubsequence().MinimumDeletionToFormPalindrominString("pqr"));
        }
    }

}