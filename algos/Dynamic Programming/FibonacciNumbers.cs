using System;
using System.Collections.Generic;

namespace algos.DynamicProgramming
{
    public class FibonacciNumbers
    {
        public int CountWaysToTop(int numberOfStairs)
        {
            return CountWaysToTop(numberOfStairs, 0, new Dictionary<int, int>());

        }

        public int CountWaysToTop(int numberOfStairs, int currentStep,  Dictionary<int, int> cache){

            if(currentStep == numberOfStairs){
                return 1;
            }

            if(currentStep > numberOfStairs){
                return 0;
            }

            if(cache.ContainsKey(currentStep)){
                return cache[currentStep];
            }

            cache[currentStep] = CountWaysToTop(numberOfStairs, currentStep + 1,  cache)
            + CountWaysToTop(numberOfStairs, currentStep + 2, cache) 
            + CountWaysToTop(numberOfStairs, currentStep + 3, cache);

            return cache[currentStep];

        }

        public int MinimumJumpsToEnd(int[] jumps)
        {
            return MinimumJumpsToEnd(jumps, 0, new Dictionary<int, int>());
        }

         public int MinimumJumpsToEnd(int[] jumps, int index, Dictionary<int, int> cache)
        {
            if(index == jumps.Length -1){
                return 0;
            }
            if(index >= jumps.Length){
                return int.MaxValue;
            }

            if(jumps[index] == 0){
                return int.MaxValue;
            }

            if(cache.ContainsKey(index)){
                return cache[index];
            }

            cache[index] = int.MaxValue;

            for(int nextJump = 1; nextJump <= jumps[index]; ++nextJump){
                var jumpsToEnd = MinimumJumpsToEnd(jumps, index + nextJump, cache);
                if(jumpsToEnd != int.MaxValue){
                    cache[index] = Math.Min(1 + jumpsToEnd, cache[index]);
                }

            }
            return cache[index];
        }

        public int MinimumJumpsToEndWithFee(int[] fees)
        {
            return MinimumJumpsToEndWithFee(fees, 0, new Dictionary<int, int>());
        }

        public int MinimumJumpsToEndWithFee(int[] fees, int currentStair, Dictionary<int, int> cache){

            if(currentStair > fees.Length){
                return 0;
            }

            if(cache.ContainsKey(currentStair)){
                return cache[currentStair];
            }

            var oneStepCost = MinimumJumpsToEndWithFee(fees, currentStair + 1, cache);
            var twoStepCost = MinimumJumpsToEndWithFee(fees, currentStair + 2, cache);
            var threeStepCost = MinimumJumpsToEndWithFee(fees, currentStair + 3, cache);



            cache[currentStair] = fees[currentStair] +  Math.Min(Math.Min(oneStepCost, twoStepCost), threeStepCost);
            return cache[currentStair];

        }

        public int HouseThief(int[] profits)
        {
            return HouseThief(profits, 0, new Dictionary<int, int>());
        }

        public int HouseThief(int[] profits, int houseNumber, Dictionary<int, int> cache){
            if(houseNumber >= profits.Length){
                return 0;
            }

            if(cache.ContainsKey(houseNumber)){
                return cache[houseNumber];
            }

            var profitCurrentHouse = profits[houseNumber] + HouseThief(profits, houseNumber + 2, cache);
            var profitSkipCurrentHouse = HouseThief(profits, houseNumber + 1, cache);
            cache[houseNumber] = Math.Max(profitCurrentHouse, profitSkipCurrentHouse);
            return cache[houseNumber];
        }


        public int CountWaysToSum(int v)
        {
            return CountWaysToSum(v, new Dictionary<int, int>());
        }

        public int CountWaysToSum(int number, Dictionary<int, int> cache){
            if(number < 0) return 0;

            if(number == 0) return 1;

            if(cache.ContainsKey(number)){
                return cache[number];
            }

            cache[number] = CountWaysToSum(number - 1, cache) + CountWaysToSum(number - 3, cache) 
            + CountWaysToSum(number -4, cache);

            return cache[number];
        }
    }
}
