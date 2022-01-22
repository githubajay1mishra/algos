using algos.Arrays;
using Microsoft;
using Xunit;

namespace algos.test.Arrays
{
    public class Tests
    {
        [Theory]
        [InlineData("()", 2)]
        public void TransformMatrix(string input, int expected)
        {
            var sol = new SolutionTransFormMatrix();
            int[][] data = {
                new int[]{1,1,1},
                new int[]{1,0,1},
                new int[]{1,1,1},

            };
            sol.TransformMatrix(data);

            Assert.Equal(new int[][]{
                new int[]{1,0,1},
                new int[]{0,0,0},
                new int[]{1,0,1},
            }, data);
        }

        [Theory]
        [InlineData("()", 2)]
        public void RotateMatrix(string input, int expected)
        {
            var sol = new SolutionTransFormMatrix();
            int[][] data = {
                new int[]{1, 2, 3},
                new int[]{4, 5, 6},
                new int[]{7, 8, 9},

            };
            sol.RotateMatrix(data);

            Assert.Equal(new int[][]{
                new int[]{7, 4 ,1},
                new int[]{8,5,2},
                new int[]{9,6,3},
            }, data);
        }
    }
    

    
}
