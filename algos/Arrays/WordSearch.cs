using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace algos.Arrays
{
    public class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    var exists = Exist(board, word, 0, new Cell(row, col), new List<string>());
                    if (exists) return true;
                }
            }

            return false;

        }

        private bool Exist(char[][] board,
                           string word,
                           int indexInWord,
                           Cell current,
                           List<string> seen)
        {

            if (indexInWord == word.Length)
            {
                return true;
            }



            var currentCharInBoard = board[current.row][current.col];
            if (currentCharInBoard != word[indexInWord])
            {
                return false;
            }

            if (indexInWord == word.Length - 1)
            {
                return true;
            }




            var result = false;
            Func<Cell, string> toSeenKey = (cell) => board[cell.row][cell.col] + $" {cell.row}:{cell.col}";
            var seenKey = toSeenKey(current);
            seen.Add(seenKey);



            var nextCells = AdjacentCells(current, board, seen);
            var nextCellsAsKeys = nextCells.Select(x => toSeenKey(x));



            foreach (var nextCell in nextCells)
            {
                if (Exist(board, word, indexInWord + 1, nextCell, seen))
                {
                    result = true;
                    break;
                }
            }

            seen.Remove(seenKey);

            return result;
        }

        private List<Cell> AdjacentCells(Cell current, char[][] board, List<String> seen)
        {
            var cells = new List<Cell>();

            if (current.row - 1 >= 0)
            {
                cells.Add(new Cell(current.row - 1, current.col));
            }

            if (current.row + 1 < board.Length)
            {
                cells.Add(new Cell(current.row + 1, current.col));
            }

            if (current.col - 1 >= 0)
            {
                cells.Add(new Cell(current.row, current.col - 1));
            }

            if (current.col + 1 < board[0].Length)
            {
                cells.Add(new Cell(current.row, current.col + 1));
            }

            Predicate<Cell> remove = (Cell cell) =>
            {
                var key = board[cell.row][cell.col] + $" {cell.row}:{cell.col}";
                return seen.Contains(key);
            };

            cells.RemoveAll(remove);





            return cells;
        }


    }

    internal struct Cell
    {
        public int row;
        public int col;

        public Cell(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public override bool Equals(object obj)
        {
            return obj is Cell other &&
                   row == other.row &&
                   col == other.col;
        }

        public override int GetHashCode()
        {
            int hashCode = -1720622044;
            hashCode = hashCode * -1521134295 + row.GetHashCode();
            hashCode = hashCode * -1521134295 + col.GetHashCode();
            return hashCode;
        }

        public void Deconstruct(out int row, out int col)
        {
            row = this.row;
            col = this.col;
        }

        public static implicit operator (int row, int col)(Cell value)
        {
            return (value.row, value.col);
        }

        public static implicit operator Cell((int row, int col) value)
        {
            return new Cell(value.row, value.col);
        }
    }
}
