using System;
using System.Collections.Generic;
using System.Linq;

namespace algos.Arrays
{
   public class NextPermutation{


       public void FindNextPermutation(int[] nums){

           for(int index = nums.Length-1; index >= 1; index--){
               var previous = nums[index-1];
               var current = nums[index];

               if(previous < current){
                   Reverse(nums, index, nums.Length-1);
                   // Find index to swap with previous.
                   // Position of the first number that is greateer than previous
                   var swapIndex = index;
                   for(int position = index; position < nums.Length; position++){
                       if(nums[position] > previous){
                           swapIndex = position;
                           break;
                       }
                   }

                   nums[index - 1] = nums[swapIndex];
                   nums[swapIndex] = previous;


                   return;
               }

           }
           
        Reverse(nums, 0, nums.Length - 1);

       }

       public void Reverse(int[] nums, int start, int end){
           while(start < end){
               var temp = nums[start];
               nums[start] = nums[end];
               nums[end] = temp;
               start++;
               end--;
           }
       }

   }

}