using System;
using System.Collections.Generic;
using System.Linq;


namespace algos.Recursion
{


    class Solution
    {
        public class Range
        {

            public (int Row, int Col) Start { get; set; } = (-1, -1);
            public (int Row, int Col) End { get; set; } = (-1, -1);

            public override string ToString() => Start + " " + End;
            public List<(int Row, int Column)> AllCells
            {

                get
                {
                    var cells = new List<(int Row, int Column)>();

                    for (int row = Start.Row; row <= End.Row; row++)
                    {

                        for (int col = Start.Col; col <= End.Col; col++)
                        {

                            cells.Add((row, col));

                        }

                    }

                    return cells;
                }
            }
        }


        static List<Range> ranges;


        static string[] crosswordPuzzle(string[] crossword, string words)
        {
            ranges = getRanges(crossword);

            
            ranges.Sort((x, y) => x.AllCells.Count.CompareTo(y.AllCells.Count));



            var grid = new List<List<char>>();
            foreach (var row in crossword)
            {
                var rowList = new List<char>();

                rowList.AddRange(row.ToList());
                grid.Add(rowList);
            }




            var answer = solve(0, words.Split(';').ToList(), grid);
           

            return answer ?? crossword;


        }

        static string[] solve(int currentRangeIndex, List<string> words, List<List<char>> gridInput)
        {


            if (currentRangeIndex >= ranges.Count)
            {
                var answer = gridInput
                              .Select(x => new string(x.ToArray()));
                return answer.ToArray();

            }

            var currentRange = ranges[currentRangeIndex];
           



            for (int index = 0; index < words.Count; index++)
            {
                var allCells = currentRange.AllCells;
                if (words[index].Length != allCells.Count)
                    continue;

                bool isFit = true;


                for (int position = 0; position < words[index].Length; position++)
                {
                    var gridChar = gridInput[allCells[position].Row][allCells[position].Column];
                    if (gridChar != '-' && gridChar != words[index][position])
                    {
                        isFit = false;
                        break;
                    }

                }

                for(int leftOver = words[index].Length; 
                isFit && leftOver < allCells.Count; leftOver++){
                    var gridChar = gridInput[allCells[leftOver].Row][allCells[leftOver].Column];

                    if(gridChar == '-'){
                        isFit = false;
                        break;
                    }

                }

                if (!isFit)
                {
                    continue;
                }

                var clone = CloneSolution(gridInput);
                var charIndex = 0;

                foreach (var cell in allCells)
                {
                    clone[cell.Row][cell.Column] = words[index][charIndex];
                    charIndex++;
                }


                var wordIndex = 0;

                

                var remainingWords = words.Where(x => wordIndex++ != index).ToList();


                var solution = solve(currentRangeIndex + 1, remainingWords, clone);

                if (solution != null)
                {
                    return solution;
                }

            }

            return null;


        }
        static List<List<char>> CloneSolution(List<List<char>> gridInput)
        {
            var clone = new List<List<char>>();

            foreach (var rowList in gridInput)
            {
                clone.Add(new List<char>());
                clone.Last().AddRange(rowList);
            }

            return clone;

        }

        static List<Range> getRanges(string[] crossword)
        {

            List<Range> ranges = new List<Range>();



            for (int i = 0; i < crossword.Length; ++i)
            {

                for (int j = 0; j < crossword[0].Length; ++j)
                {
                    var currentCharacter = crossword[i][j];

                    if (currentCharacter == '-')
                    {

                        if (j == 0 || crossword[i][j - 1] != '-')
                        {
                            var hRange = new Range();
                            hRange.Start = (i, j);


                            for (int col = j + 1; col < crossword[0].Length; col++)
                            {
                                if (crossword[i][col] != '-')
                                {
                                    break;
                                }



                                hRange.End = (i, col);


                            }

                            if (hRange.AllCells.Count > 1)
                            {
                                ranges.Add(hRange);
                            }
                        }

                        if (i == 0 || crossword[i - 1][j] != '-')
                        {
                            var vRange = new Range();
                            vRange.Start = (i, j);




                            for (int row = i + 1; row < crossword.Length; row++)
                            {
                                if (crossword[row][j] != '-')
                                {
                                    break;
                                }

                                vRange.End = (row, j);


                            }

                            if (vRange.AllCells.Count > 1)
                            {
                                ranges.Add(vRange);
                            }
                        }
                    }

                }
            }

            return ranges;
        }

    }

}