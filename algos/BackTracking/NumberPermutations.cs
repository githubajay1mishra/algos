using System.Collections.Generic;
using System.Linq;

namespace algos.BackTracking
{
    public class NumberPermutations {
    
    public IList<IList<int>> PermuteUnique(int[] nums) {
        
        var allResults = PermuteUnique(nums, 0, new Dictionary<int, int>());
        var unique = new HashSet<string>();
        return allResults.Where(x => {
            return unique.Add(string.Join(",", x));
        }).ToList();
        
    }
    
    public IList<IList<int>> PermuteUnique(int[] nums, int length, Dictionary<int, int> memo)
    {
        var results = new List<IList<int>>();

        if(nums.Length == memo.Count){
            var result = new int[nums.Length];
            foreach(var entry in memo){
                var number = nums[entry.Key];
                result[entry.Value] = number; 
            }
            
            results.Add(result.ToList());
            
            return results;
        }
        
        
        for(int index = 0; index < nums.Length; index++){
            // This number is already added
            if(memo.ContainsKey(index)){
                continue; 
            }
            
            memo[index] = length;
            
            
            
            var result = PermuteUnique(nums, length + 1, memo);
            
            results.AddRange(result);
            
            
            memo.Remove(index);
            
        }
        
        return results;
        
    }
}
}
