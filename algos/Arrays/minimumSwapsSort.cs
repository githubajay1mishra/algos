using System;
using System.Collections.Generic;

namespace algos.Arrays{
 public class SolutionSortArrayMinimumSwaps{
     /*
         complexity time is nlogn
         space complexity n

         // minimum swaps required to sort a graph cycle with k elements is k - 1
         // create a new array with element value and original position
         // sort the array by element value
         // create a visited graph array
         // traverse the new array
         //  do if current element original position is same as sorted 
         //       or
         //        current element was visited do nothing
         //    traverse the graph cycle until you find visited node
         //         while travsering we mark that the node has been visited
         //         add to count number of elements in graph
         // add to answer = count of elements in graph - 1 (if count > 0)        

     */

     static int minimumSwaps(int[] arr){
        var pairs = new List<(int expectedPosition, int originalPosition)>();
        
        for(int index = 0; index < arr.Length; index++)
        {
            pairs.Add((arr[index] - 1, index));                    
        }
        
        
        
        pairs.Sort((x, y) => 
                   {
                       if(x.expectedPosition < y.expectedPosition){
                          return -1;
                       }
                       
                       if(x.expectedPosition == y.expectedPosition){
                          return 0;
                       }
                       
                       return 1;
                   });
        
        var visited = new bool[arr.Length];
        var answer = 0;
        
        for(int index = 0; index < pairs.Count; ++index){            
                        
            var j = index;
            var countInGraph = 0;
            
            while( !(pairs[j].originalPosition == j 
                     ||   
                     visited[j]))
            {
                visited[j] = true;           
                j = pairs[j].originalPosition;
                countInGraph++;
            }
            
            
            answer += countInGraph > 0 ? countInGraph - 1: 0;
            
        
        }
        
        
        return answer;
    }
 }

}