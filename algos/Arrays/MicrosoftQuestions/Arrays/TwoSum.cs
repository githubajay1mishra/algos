using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> previousValuesToIndex = new Dictionary<int, int>();
        
        for(int index = 0; index < nums.Length; ++index){
            var valueAtCurrentIndex = nums[index];
            var valueToLookUp = target - valueAtCurrentIndex;
            
            if(previousValuesToIndex.ContainsKey(valueToLookUp)){
                return new int[]{previousValuesToIndex[valueToLookUp], index};
            }
            
            previousValuesToIndex[valueAtCurrentIndex] = index;
        }
        
        return new int[]{-1, -1};
    }
}