using System.Linq;
using System;
using System.Collections.Generic;

public class CombinationSumSolution {
     
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        
        var sort = candidates.Where(x => x <= target)
                     .ToList();
                     
        sort.Sort();
        Console.WriteLine(String.Join(",", sort));
        var result = new List<IList<int>>();
        var memo = new HashSet<string>();
        DPSum(sort.ToArray(), target, 0, new List<int>(), result, memo);
        result.Sort((x, y) => y.Count.CompareTo(x.Count));
        
        return result;
    }
    
    public  void DPSum(int[] candidates, 
                       int remaining,
                       int index,
                       List<int> comb,
                       List<IList<int>> result,
                       HashSet<string> memo){

         var key =  string.Join(",", comb) + ":" +  index;
        if(memo.Contains(key)){
            Console.WriteLine("Retuned key" +  key);
            return;
            
        }
        
        
        memo.Add(key);             

     
        
        
        if(remaining < 0){
            return;
        }
                
        if(index > candidates.Length - 1){
            return;
        }
        
         
        
        if(remaining == 0){
            // if(result.Any(item => item == comb)){
            //     return;
            // }
            Console.WriteLine($"{index} added result:" + string.Join(",", comb));
            result.Add(new List<int>(comb));
            return;
        }
        
        if(comb.Count == 150){
            return;
        }

         
       
        
        // Move to next
        DPSum(candidates, 
              remaining, 
              index + 1, 
              new List<int>(comb), 
              result,
              memo);

        
        // Take current
        var combClone = new List<int>(comb);
        combClone.Add(candidates[index]);
        DPSum(candidates, 
              remaining - candidates[index], 
              index, 
              combClone, 
              result,
              memo);
        
       
        
    }
    
     
}