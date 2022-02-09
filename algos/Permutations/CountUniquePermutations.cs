using System.Linq;
using System.Collections.Generic;
using System;
namespace algos.Permutations{
     
     public class CountUniquePermuations{
         private Dictionary<int, int> _factorial = new Dictionary<int, int>();
        
         public int CountPermutations(int[] nums){

             if(nums == null || nums.Length < 1){
                 return 0;
             }

             Array.Sort(nums);

            var frequencyMap = new Dictionary<int, int>();
            foreach(var number in nums){
                frequencyMap[number] = frequencyMap.ContainsKey(number) ? frequencyMap[number] + 1 : 1;
            }

             var distinctPairs = FindDistinctPairsThatSatifyConstraint(nums);
             var count = 0;

             foreach(var pair in distinctPairs){
                 var mapForPairRemainingElements = new Dictionary<int, int>(frequencyMap);
                 mapForPairRemainingElements[pair.leftValue] -= 1;
                 mapForPairRemainingElements[pair.rightValue] -= 1;
                 var remaining = mapForPairRemainingElements.Where(x => x.Value > 0).ToDictionary(item => item.Key, item => item.Value);

                 var firstLastPermutationMultiplier = pair.rightValue == pair.leftValue ? 1 : 2;
                 count += (firstLastPermutationMultiplier *  RemainingPermutationCount(remaining, nums.Length - 2));
               
                 
                 
             }

             return count;
            
         }

         private int Factorial(int number){
             if(number < 2) return 1;

             if(_factorial.ContainsKey(number))
             return _factorial[number];

             int fact = 1;

             for(int term = 1; term <= number; term++){
               fact *= term;
               _factorial[term] = fact;
             }

             return _factorial[number];

         }

         private int RemainingPermutationCount(Dictionary<int, int> remainingElements, int totalRemainingLength){
                 if(totalRemainingLength <=  1)
                   return 1;

                   var countPermutationsRemaining = Factorial(totalRemainingLength);
                   var duplicates = 1;
                   foreach(var kvp in remainingElements){
                       if(kvp.Value > 1){
                          duplicates *= Factorial(kvp.Value);
                       }
                   }

                   return countPermutationsRemaining / duplicates;
             
         }



         private HashSet<(int leftValue, int rightValue)> FindDistinctPairsThatSatifyConstraint(int[] nums){
            var pairs = new HashSet<(int leftIndex, int rightIndex)>();
            var sum = nums.Sum();
            for(int leftIndex = 0; leftIndex < nums.Length - 1; leftIndex++){
                for(int rightIndex = leftIndex + 1; rightIndex < nums.Length; rightIndex++){

                    var sumPair = nums[leftIndex] + nums[rightIndex];
                    if(sumPair > sum - sumPair){
                          pairs.Add((nums[leftIndex], nums[rightIndex]));

                    }
                }
            }

            return pairs;

         }

     }


}