using algos.Stacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace algos.test.Stack
{
    public class MaximalRectangleMatrixTests
    {
        [Theory]
        [MemberData(nameof(Data))]

        public void Validate(char[][] data, int expected)
        {
            var sol = new MaximalRectangleMatrix();
            Assert.Equal(expected, sol.MaximalRectangle(data));
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[]{ new char[][] { new char[] { '1' } }, 1},
            new object[]{ new char[][] { new char[] { '0' } }, 0},
            new object[]{ new char[][] {
            new char[] {'1','0','1','0','0' },
            new char[] {'1','0','1','1','1' },
            new char[] {'1','1','1','1','1' },
            new char[] {'1','0','0','1','0' }
            }, 6},

        };
    }
}
