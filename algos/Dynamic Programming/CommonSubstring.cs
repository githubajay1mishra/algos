using System;
namespace algos.DynamicProgrammng
{
    class SolutionCommonSubstring{

        static int commonChild(string s1, string s2) {
        // Create a jagged array with one extra row and column than length of string            
        int[,] matrix = new int[s1.Length +1, s2.Length + 1];
        
        var result = 0;
        
        for(int i = 0; i <= s1.Length; ++i)
        {
            for(int j = 0; j <= s2.Length; ++j)
            {
                // first row and index has really no meaning just to make program simple
                if(i == 0 || j == 0)
                {
                    matrix[i, j] = 0;
                    continue;
                }
                
                // Characters are current indexes match
                if(s1[i-1] == s2[j-1])
                {
                    // all  previous matches in both string  + 1 (for one more match)                     
                    matrix[i, j] = matrix[i-1, j-1] + 1;
                    result = Math.Max(result, matrix[i, j]);
                }else{
                    // no match at current, 
                    // so match count at current  is max of matches without characters are current index                 
                     
                    matrix[i, j] = Math.Max(matrix[i-1, j],matrix[i, j-1]);                
                }               
                
            
            }
        
        }
        
        return result;


    }



    }
    
}