using System;
using System.Collections.Generic;
using System.Linq;

namespace algos.Arrays{

    public class Kadane{

        public static void Main(string[] args){
            var numberOfTestCases = int.Parse(Console.ReadLine().Trim());
            // Console.WriteLine($"Number of testcases {numberOfTestCases}");
            for(int i = 0; i < numberOfTestCases; i++){
                
                var lengthString = Console.ReadLine().Trim().Split(' ');
                var length = int.Parse (lengthString[0]);
                // Console.WriteLine($"Length:{length}");
                 var dataArray = Console.ReadLine().Trim().Split(' ')
                                .Select(x => int.Parse(x))
                                .ToArray();
                 // Console.WriteLine($"Parsed data:{dataArray.Length} Sum:{string.Join(",", dataArray.Select(x => x.ToString())) }");

                 Console.WriteLine($"{KadaneAlgo(dataArray)}");
            }



        }
     



      public static int  KadaneAlgo(int[] array){
          int maxSum = array[0];
          (int start, int end, int sum) currArray = (0,0, array[0]);

           for(int index = 1; index < array.Length; ++index){
               if(array[index] >= 0){

                   if(currArray.sum < 0){
                       currArray = (index, index, array[index]);
                   } else{
                       currArray.sum += array[index];
                       currArray.end = index;                       
                 }               
                 
                 
               } else{
                   if(currArray.sum > 0){
                       currArray.sum += array[index];
                       currArray.end = index;   
                       
                   } else{
                       currArray = (index, index, array[index]);                       
                 }
                   
               }

               if(currArray.sum > maxSum){
                     maxSum = currArray.sum;
                 }

           }          

          return maxSum;
          
      }     

     
    }

}


