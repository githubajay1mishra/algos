using Xunit;
using algos.Strings;

namespace algos.test.Strings
{
    public class PalindromicNumberTests
    {

        [Theory]
        [InlineData(0, true)]
        [InlineData(11, true)]
        [InlineData(123456, false)]
        [InlineData(121, true)]
        [InlineData(-121, false)]
        [InlineData(999, true)]

        public void Validate(int number, bool isPalidrome)
        {
            Assert.Equal(isPalidrome, new PalindromicStrings().IsPalindromic(number));

        }

       

    }

    
}