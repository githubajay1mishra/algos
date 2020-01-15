using System;
using System.Collections.Generic;
using System.Linq;

namespace algos.Arrays{

    public class SumSubArray{

        public static void Main(string[] args){
            var numberOfTestCases = int.Parse(Console.ReadLine().Trim());
            // Console.WriteLine($"Number of testcases {numberOfTestCases}");
            for(int i = 0; i < numberOfTestCases; i++){
                
                var lengthAndSumString = Console.ReadLine().Trim().Split(' ');
                var length = int.Parse (lengthAndSumString[0]);
                var sum = int.Parse (lengthAndSumString[1]);
                // Console.WriteLine($"Length:{length} Sum:{sum}");
                 var dataArray = Console.ReadLine().Trim().Split(' ')
                                .Select(x => int.Parse(x))
                                .ToArray();
                 // Console.WriteLine($"Parsed data:{dataArray.Length} Sum:{string.Join(",", dataArray.Select(x => x.ToString())) }");

                 (int startIndex, int endIndex) info = GetSubArrayThatMatchesSum(dataArray, sum); 

                if(info.startIndex == -1)
                {
                    Console.WriteLine("-1");
                } 
                else
                {
                    Console.WriteLine($"{info.startIndex} {info.endIndex}");
                }




            }



        }
     
        public static int CumulativeSum(int[] arr){
            var maxSum = arr[0];
        var cumulativeSum = arr[0];

        for(int index = 1; index < arr.Length; index++){

            if(cumulativeSum <= 0){
                cumulativeSum = arr[index];                
            } else{
                cumulativeSum += arr[index];
            }

            if(cumulativeSum > maxSum){
                maxSum = cumulativeSum;
            }

        }

        return maxSum;

        }


      public static (int, int)  GetSubArrayThatMatchesSumDC(int[] array, int sumToMatch){
          Dictionary<int, int> mapSubArraySumPosition = new Dictionary<int, int>();

           var sum = 0;
          for(int i = 0; i < array.Length; i++){
              sum += array[i];

              if(sum == sumToMatch){
                  return (1, i+ 1);
              }
              // if this is an end of array of continous element that add up to needed num
              // then total sum =  "sum before continous array" + "Need Sum"
              // "sum before continous array" = total Sum - "Need Sum"
              // check if sum - neededSum exists in the map if it does then we have array block
              else if(mapSubArraySumPosition.Keys.Contains(sum -sumToMatch)){
                  var indexStart = mapSubArraySumPosition[sum - sumToMatch] + 1; 
                  return (indexStart + 1, i + 1);
              }

              mapSubArraySumPosition[sum] = i;
          }

          return (-1, -1);
      }

      /*
        Given a list of non-negative numbers and a target integer k, 
        write a function to check if the array has a continuous subarray of size at least 2 
        that sums up to a multiple of k, that is, sums up to n*k where n is also an integer
      */

      public static bool CheckSubarraySum(int[] nums, int k) {
        
        if(k == 0){
              for(int index = 0; index < nums.Length - 1; index++)
              {
                  if(nums[index] == 0
                  &&
                  nums[index + 1] == 0){
                      return true;
                  }

              }

              return false;
          }
        
        var modLookUp = new Dictionary<int, int>();
        var sum = 0;
          
          for(int index = 0; index < nums.Length; index++)
          {
              sum += nums[index];

              if(sum % k == 0 && index > 0){
                  return true;
              }

              if(modLookUp.ContainsKey(sum%k) 
                &&
                index - modLookUp[sum%k] > 1)
                {
                    return true;

                }

              if(nums[index] != 0){
                  modLookUp[sum%k] = index;
              }  

          }

          return false;
        
    }

        public static (int, int)  GetSubArrayThatMatchesSum(int[] array, int sumToMatch){
            int indexStart = 0;
            int lastIndex = array.Length - 1;

            while(indexStart <= lastIndex){
                var sum = 0;

                for(int subEndIndex = indexStart; subEndIndex <= lastIndex; subEndIndex++){
                    sum += array[subEndIndex];
                    if(sum == sumToMatch){
                        return (indexStart + 1, subEndIndex + 1);
                    }

                }

                ++indexStart;
                
            }


            return (-1, -1);
        }


    }

}