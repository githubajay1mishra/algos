using System.Collections.Generic;

namespace algos.Arrays.MicrosoftQuestions.SpriralOrder
{
    public class Solution
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var spiralOrder = new List<int>();
            var numberOfRows = matrix.Length;
            var numberOfColumns = matrix[0].Length;
            var maxIterations = numberOfRows < numberOfColumns ? numberOfRows / 2
            : numberOfColumns / 2;

            for (int iteration = 0; iteration <= maxIterations; ++iteration)
            {
                var endRow = numberOfRows - iteration;
                var endCol = numberOfColumns - iteration;

                // add top
                for (int topColIndex = iteration; topColIndex <= endCol; ++topColIndex)
                {
                    spiralOrder.Add(matrix[iteration][topColIndex]);
                }


                // add right
                for (int rightRowIndex = iteration + 1; rightRowIndex <= endRow; ++rightRowIndex)
                {
                    spiralOrder.Add(matrix[rightRowIndex][endCol]);
                }


                if (iteration < endRow)
                {
                    // add bottom
                    for (int bottomColIndex = endCol - 1; bottomColIndex >= iteration; --bottomColIndex)
                    {
                        spiralOrder.Add(matrix[endRow][bottomColIndex]);
                    }
                }

                if (iteration < endCol)
                {

                    // add left
                    for (int leftRowIndex = endRow - 1; leftRowIndex >= iteration; --leftRowIndex)
                    {
                        spiralOrder.Add(matrix[leftRowIndex][iteration]);
                    }
                }

            }

            return spiralOrder;

        }
    }
}