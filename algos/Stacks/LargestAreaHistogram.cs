using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algos.Stacks
{
    public class LargestAreaHistogram 
    {
        public int LargestRectangleArea(int[] heights)
        {
            var stackHeights = new Stack<int>();
            var result = 0;
            for(int i = 0; i < heights.Length; i++)
            {
                while(stackHeights.Count > 0 && heights[i] <= heights[stackHeights.Peek()])
                {
                    var prevTop = stackHeights.Pop();
                    var barHeight = heights[prevTop];
                    var width = stackHeights.Count == 0 ? i : (i-1) - stackHeights.Peek();
                    var area = barHeight * (width);
                    result = Math.Max(area, result);

                }

                stackHeights.Push(i);
            }
         

            while(stackHeights.Count > 0)
            {
                
                var prevTop = stackHeights.Pop();
                var barHeight = heights[prevTop];
                var width = stackHeights.Count == 0 ? heights.Length : (heights.Length - 1) - stackHeights.Peek();
                var area = barHeight * width;
                result = Math.Max(area, result);
            }

            return result;

            
        }
    }
}
