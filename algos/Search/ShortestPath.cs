using System;
using System.Collections.Generic;
using System.Linq;

namespace algos.Search
{
    public class Solution
    {
        public class Move
        {
            public int Row { get; set; }
            public int Column { get; set; }
            public int Count { get; set; }
        }

        static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY)
        {
            var bfs = new List<Move>();

            var move = new Move()
            {
                Row = startX,
                Column = startY,
                Count = 0,
            };

            bfs.Add(move);


            var gridSolve = new List<List<int>>();
            foreach (var rowString in grid)
            {
                Console.WriteLine(rowString);
                var gridRow = new List<int>();
                foreach (var charInRow in rowString)
                {
                    gridRow.Add(charInRow == 'X' ? int.MinValue : int.MaxValue);
                }

                gridSolve.Add(gridRow);
            }

            while (bfs.Count > 0)
            {
                Move curMove = bfs[0];
                bfs.RemoveAt(0);
                var nextMoves = GetNextMoves(curMove, gridSolve);
                foreach (var nextMove in nextMoves)
                {
                    bfs.Add(nextMove);
                }

            }

            return gridSolve[goalX][goalY];
        }

        static List<Move> GetNextMoves(Move currentMove, List<List<int>> grid)
        {

            var nextMoves = new List<Move>();

            for (int row = currentMove.Row - 1; row >= 0; row--)
            {

                if (grid[row][currentMove.Column] == int.MinValue)
                {
                    break;
                }

                if (currentMove.Count + 1 >= grid[row][currentMove.Column])
                {
                    continue;
                }

                grid[row][currentMove.Column] = currentMove.Count + 1;

                nextMoves.Add(new Move()
                {
                    Row = row,
                    Column = currentMove.Column,
                    Count = currentMove.Count + 1
                });

            }

            for (int row = currentMove.Row + 1; row < grid.Count; row++)
            {

                if (grid[row][currentMove.Column] == int.MinValue)
                {
                    break;
                }

                if (currentMove.Count + 1 >= grid[row][currentMove.Column])
                {
                    continue;
                }

                grid[row][currentMove.Column] = currentMove.Count + 1;

                nextMoves.Add(new Move()
                {
                    Row = row,
                    Column = currentMove.Column,
                    Count = currentMove.Count + 1
                });

            }

            for (int col = currentMove.Column - 1; col >= 0; col--)
            {

                if (grid[currentMove.Row][col] == int.MinValue)
                {
                    break;
                }

                if (currentMove.Count + 1 >= grid[currentMove.Row][col])
                {
                    continue;
                }

                grid[currentMove.Row][col] = currentMove.Count + 1;

                nextMoves.Add(new Move()
                {
                    Row = currentMove.Row,
                    Column = col,
                    Count = currentMove.Count + 1
                });

            }

            for (int col = currentMove.Column + 1; col < grid.Count; col++)
            {

                if (grid[currentMove.Row][col] == int.MinValue)
                {
                    break;
                }

                if (currentMove.Count + 1 >= grid[currentMove.Row][col])
                {
                    continue;
                }

                grid[currentMove.Row][col] = currentMove.Count + 1;

                nextMoves.Add(new Move()
                {
                    Row = currentMove.Row,
                    Column = col,
                    Count = currentMove.Count + 1
                });

            }
            return nextMoves;
        }
    }

}