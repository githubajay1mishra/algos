using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

public class SudokuSolver{

    public void SolveSudoku(char[][] input)
    {
        
        var cellsInRow = new List<HashSet<char>>();
        var cellsInCol = new List<HashSet<char>>();
        var cellsInMatrix = new List<HashSet<char>>();
        
        for(int index = 0; index < 9; index++)
        {
            cellsInRow.Add(new HashSet<char>(GetCellsInSameRow(input, index).Where(x => x != '.')) );
            cellsInCol.Add(new HashSet<char>(GetCellsInSameCol(input, index).Where(x => x != '.')));
            cellsInMatrix.Add(new HashSet<char>(GetCellsInSameMatrix(input, index).Where(x => x != '.')));
            
        }

      var unsolved = new List<Unsolved>();

      for(int row = 0; row < 9; row++){
          for(int col = 0; col < 9; col++){
              if(input[row][col] != '.'){
                  continue;
              }
              var options = new HashSet<char>(new char[]{'1', '2', '3', '4', '5', '6', '7', '8', '9'});
              options.ExceptWith(cellsInRow[row]);
              options.ExceptWith(cellsInCol[col]);
              var matrix = GetMatrix(row, col);
              options.ExceptWith(cellsInMatrix[matrix]);
              unsolved.Add(new Unsolved(row, col, options));

          }
      }
            

      if(unsolved.Count < 1){
          return;
      }

      unsolved.Sort(CompareOptions);
      

      foreach(var cell in unsolved)
      {
          foreach(char option in cell.Options)
          {
                input[cell.Row][cell.Column] = option;
                SolveSudoku(input);
                var solved = Array.TrueForAll(input, (row) => Array.TrueForAll(row, (x => x != '.'))); 
                if(!solved){
                    input[cell.Row][cell.Column] = '.';
                }else{
                    return;
                }
          }
      }

    }

 


    public static int CompareOptions(Unsolved x, Unsolved y){
        return x.Options.Count.CompareTo(y.Options.Count);
    }

    

    public struct Unsolved{
        public Unsolved(int row, int col, HashSet<char> options)
        {
            Row = row;
            Column = col;
            Options = options;
        }

        public int Row;
        public int Column;
        public HashSet<char> Options;
    }

    private int GetMatrix(int row, int col){

        if(row <= 2){

            if(col <= 2) return 0;
            if(col <= 5) return 1;
            return 2;
        }

        if(row <= 5){

            if(col <= 2) return 3;
            if(col <= 5) return 4;
            return 5;

        }

        if(col <= 2) return 6;
        if(col <= 5) return 7;
        return 8;
    }

    private HashSet<char> GetCellsInSameRow(char[][] input, int row){
        var inRow = new HashSet<char>();
        for(int col = 0; col < 9; col++){
           
               inRow.Add(input[row][col]);
           
        }

        return inRow;
    }

    private HashSet<char> GetCellsInSameCol(char[][] input, int col){
        var inColumn = new HashSet<char>();
        for(int row = 0; row < 9; row++){
        
               inColumn.Add(input[row][col]);
           
        }

        return inColumn;

    }

    

    
    private HashSet<char> GetCellsInSameMatrix(char[][] input, int matrix){
       HashSet<char> inMatrix = new HashSet<char>();
      
       int rowStart = 0; 
       int colStart = 0;

       switch(matrix){
           case 0:
           rowStart = 0;
           colStart = 0;
           break;
           case 1:
           rowStart = 0;
           colStart = 3;
           break;
           case 2:
           rowStart = 0;
           colStart = 6;
           break;
           case 3:
           rowStart = 3;
           colStart = 0;
           break;
           case 4:
           rowStart = 3;
           colStart = 3;
           break;
           case 5:
           rowStart = 3;
           colStart = 6;
           break;
           case 6:
           rowStart = 6;
           colStart = 0;
           break;
           case 7:
           rowStart = 6;
           colStart = 3;
           break;
           case 8:
           rowStart = 6;
           colStart = 6;
           break;
       }

       for(int row = rowStart; row <= rowStart + 2; row++){
           for(int col = colStart; col <= colStart + 2; col++){
               inMatrix.Add(input[row][col]);


           }

       }


       return inMatrix;
 

    }




}
