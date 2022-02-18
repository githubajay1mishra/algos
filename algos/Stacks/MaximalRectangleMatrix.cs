using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algos.Stacks
{
    public class MaximalRectangleMatrix
    {
        public int MaximalRectangle(char[][] matrix)
        {
            var result = matrix.Select(x => x.Select(value => (int)char.GetNumericValue(value)).ToArray()).ToArray();
            for(int row = 1; row < result.Length; row++) {
                for (int col = 0; col < result[row].Length; col++) { 
                    result[row][col] = result[row][col] == 1 ? result[row-1][col] + 1 : result[row][col];
                }
            }
            var maxRectangleArea = 0;
            foreach (var row in result) {
                maxRectangleArea = Math.Max(maxRectangleArea, CalculateMaxArea(row));
            }
            return maxRectangleArea;
        }

        public int CalculateMaxArea(int[] heights)
        {
            int maxArea = 0;
            var stackHeights = new Stack<int>();
            for (int i = 0; i < heights.Length; i++)
            {
                while(stackHeights.Count > 0 && heights[i] <= heights[stackHeights.Peek()]){

                    var prevTop = stackHeights.Pop();
                    var height = heights[prevTop];
                    var width = stackHeights.Count == 0 ? i: i - 1 - stackHeights.Peek();
                    maxArea = Math.Max(maxArea, height * width);
                }

                stackHeights.Push(i);
            }
            while (stackHeights.Count > 0) {
                var prevTop = stackHeights.Pop();
                var height = heights[prevTop];
                var width = stackHeights.Count == 0 ? heights.Length: heights.Length - 1 - stackHeights.Peek();
                maxArea = Math.Max(maxArea, height * width);
            }
            return maxArea;
        }
    }
}
