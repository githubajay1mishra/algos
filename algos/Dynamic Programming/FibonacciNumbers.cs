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
