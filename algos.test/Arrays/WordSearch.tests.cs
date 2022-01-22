using algos.Arrays;
using Xunit;

namespace algos.test.Arrays
{

    public class WordSearchTests
    {
        [Fact]
        public void Test1()
        {
            var input = new char[][]
            {
                new char[]{ 'A','B','C','E' }, 
                new char[]{'S', 'F', 'C', 'S' },
                new char[]{'A', 'D', 'E', 'E' }
            };

            var wordSearch = new WordSearch();
            Assert.True(wordSearch.Exist(input, "SEE"));
            Assert.True(wordSearch.Exist(input, "ABCCED"));
            Assert.False(wordSearch.Exist(input, "ABCB"));

            var input2 = new char[][]
          {
                new char[]{ 'A','B','C','E' },
                new char[]{'S', 'F', 'E', 'S' },
                new char[]{'A', 'D', 'E', 'E' }
          };
            Assert.True(wordSearch.Exist(input2, "ABCESEEEFS"));
          

        }

    }
}
