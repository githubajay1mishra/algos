using System;
using System.Collections.Generic;

namespace algos.DynamicProgramming
{
    public class UnboundedKnapsack
    {
        public int MaximumRodCut(int[] cuts, int total){
            var result = MaximumRodCut(cuts, total, 0, new Dictionary<string, int>());
            return result == int.MinValue ? -1 : result;
        }

        public int MaximumRodCut(int[] cuts, int total, int index, Dictionary<string, int> cache){
            if(total == 0){
                return 0;
            }

            if(index >= cuts.Length  || total < 0){
                return int.MinValue;
            }

            var key = $"{index}-{total}";
            if(cache.ContainsKey(key)){
                return cache[key];
            }

            var count1 = MaximumRodCut(cuts, total, index + 1, cache);
            var count2 = MaximumRodCut(cuts, total - cuts[index], index, cache);
            if(count2 != int.MinValue){
                count2 += 1;
            }

            cache[key] = Math.Max(count1, count2);

            return cache[key];


        }


        public int MinimumCoinChangeTopDown(int[] coins, int total){
          var result = MinimumCoinChange(coins, total, 0, new Dictionary<string, int>());
          return (result == int.MaxValue) ? - 1 : result;

        }

        public int MinimumCoinChange(int[] coins, int total, int index, Dictionary<string, int> cache){
            if(total == 0){
                return 0;
            }

            if(index >= coins.Length || total < 0){
                return int.MaxValue;
            }

            var key = $"{index}-{total}";
            if(cache.ContainsKey(key)) return cache[key];

            var count1 = MinimumCoinChange(coins, total, index + 1, cache);
            var count2 = MinimumCoinChange(coins, total - coins[index], index, cache);
            if(count2 != int.MaxValue) {
                count2 = count2 + 1;
            };
            cache[key] =  Math.Min(count1, count2);
            return cache[key];

        }

      

        public int CoinChangeTopDown(int[] coins, int total)
        { 
            return CoinChangeTopDown(coins, total, 0, new Dictionary<string, int>());

        }

        public int CoinChangeTopDown(int[] coins, int sumRemaining, int index, Dictionary<string, int> cache){
            if(sumRemaining == 0){
                return 1;
            }

            if(sumRemaining < 0 || index >= coins.Length){
                return 0;  
            }   

            var cacheKey = ToCacheKey(index, sumRemaining);

            if(cache.ContainsKey(cacheKey)){
                return cache[cacheKey];
            }

            var count1 = this.CoinChangeTopDown(coins, sumRemaining, index + 1,  cache);
            
            var count2 = CoinChangeTopDown(coins, sumRemaining - coins[index], index,  cache);
            cache[cacheKey] =  count1 +  count2;
            return cache[cacheKey] ;

        }

        private string ToCacheKey(int index, int total){
            return $"{index}-{total}";
        }

        public int CutRodBottomUp(int length, int[] cutLengths, int[] profits){
            var dp = new int[cutLengths.Length, length + 1];

            for(int rodLength = 1; rodLength <= length; rodLength++){
               int selectedCut = 0; 
               foreach(var cutLength in cutLengths){
                   var profit = profits[selectedCut];

                   var profitWithCurrentCut = cutLength <= rodLength ?
                      profit + dp[selectedCut, rodLength - cutLength] : 0;

                   var profitWithoutCurrentCut = selectedCut > 0 ?  dp[selectedCut - 1, rodLength] : 0; 

                   dp[selectedCut, rodLength] = Math.Max(profitWithCurrentCut, profitWithoutCurrentCut);  
                   selectedCut++;
               }

            }


            return dp[cutLengths.Length -1, length];

        }
        public int TopDown(int[] weights, int[] profits, int capacity){
            var dp = new int[weights.Length, capacity + 1];
            for(int x = 0; x < weights.Length; x++){
                for(int y = 0; y <= capacity; y++){
                    dp[x,y] = -1;
                }
            }

            return SolveKnapsack(weights, profits, capacity, dp, 0);
        }

        public int SolveKnapsack(int[] weights, int[] profits, int capacity, int[,] dp, int currentIndex){
            if(capacity < 1 || currentIndex >= weights.Length ){
                return 0;
            }

            if(dp[currentIndex, capacity] > -1){
                return dp[currentIndex, capacity];
            }

            var currentWeight = weights[currentIndex];
            var currentProfit = profits[currentIndex];


            var profit1 = currentWeight <= capacity ? currentProfit + SolveKnapsack(weights, 
                                             profits, 
                                             capacity - currentWeight,
                                             dp,
                                             currentIndex)  : 0;

            var profit2  =  SolveKnapsack(weights, 
                                             profits, 
                                             capacity,
                                             dp,
                                             currentIndex + 1);
            dp[currentIndex, capacity] =  Math.Max(profit1, profit2);

            return dp[currentIndex, capacity];

        }
    }
}
