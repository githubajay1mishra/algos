using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using algos.Strings;

namespace algos.test.Strings
{
    public class GenerateParensTests
    {
        [Theory]
        [InlineData(1, new string[] { "()" })]
        [InlineData(2, new string[] { "()()", "(())" })]
        [InlineData(3, new string[] { "((()))", "(()())", "(())()", "()(())", "()()()" })]
        public void Validate(int num, string[] expected)
        {
            var expectedlist = expected.ToList();
            expectedlist.Sort();
            var result = new ParensGenerator().GenerateParenthesis(num).ToList();
            result.Sort();
            Assert.Equal(expectedlist, result);
        }
    }

}
