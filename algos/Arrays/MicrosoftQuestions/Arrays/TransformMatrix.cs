using System.Linq;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Text;

namespace Microsoft
{


    public class SolutionTransFormMatrix
    {
        public void TransformMatrix(int[][] matrix)
        {
            var setFirstRowZero = matrix[0].Any(x => x == 0);
            var setFirstColumnZero = matrix.Any(x => x[0] == 0);

            for(int row = 1; row < matrix.Length; row++){
                for (int col = 1; col < matrix[0].Length; col++)
                {
                    if(matrix[row][col] == 0){
                        matrix[0][col] = 0;
                        matrix[row][0] = 0;

                    }
                    
                }
            }

            for(int row = 1; row < matrix.Length; row++){
                for (int col = 1; col < matrix[0].Length; col++)
                {
                    if(matrix[row][0] == 0 || matrix[0][col] == 0){
                        matrix[row][col] = 0;
                    }
                    
                }
            }

            if(setFirstRowZero){
               for (int col = 0; col < matrix[0].Length; col++)
               {
                   matrix[0][col] = 0;
               }
            }

            if(setFirstColumnZero){
               for (int row = 0; row < matrix.Length; row++)
               {
                   matrix[row][0] = 0;
               }
            }

        }

        public void RotateMatrix(int[][] data)
        {
            var last = data.Length - 1;
            var mid = (last)/ 2;  

            for(int row = 0; row <= mid; row++){
                for(int col = row; col < last-row; col++){

                    
                    var next = data[last-col][row];
                    data[last-col][row] =  data[last-row][last-col];  
                     data[last-row][last-col] = data[col][last-row];  
                     data[col][last-row] = data[row][col];
                     data[row][col] = next;
                }

                
            

            }
        }
    
    
        
 
    }


}
