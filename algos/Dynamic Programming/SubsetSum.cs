using System.Collections.Generic;

namespace algos{

    namespace DynamicProgramming{

        public class SubsetSum{

            public bool TopDownSubSetSum(int[] numbers, int sum){
                if(sum % 2 != 0) return false;
                var dp = new Dictionary<string, bool>();
                return CanPartition(dp, numbers, 0, sum/2);

            }

            public bool CanPartition(Dictionary<string, bool> dp, int[] numbers, int index, int sumRemaining){
                if(sumRemaining == 0) return true;
                if(index > numbers.Length - 1) return false;

                var key = $"{index}:{sumRemaining}"; 

                if(dp.ContainsKey(key)){
                   return dp[key];
                }

                var currentNumber = numbers[index];

                dp[key] =  ((currentNumber <= sumRemaining) && this.CanPartition(dp, numbers,  index + 1, sumRemaining - currentNumber))
                           || 
                           this.CanPartition(dp, numbers,  index + 1, sumRemaining);
            
                 return dp[key];                
            }


            public bool bottomUpSubSetSum(int[] numbers, int sum){
                 return false;

            }
            
        }

    }
}