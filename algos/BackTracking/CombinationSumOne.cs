using System.Collections.Generic;

namespace algos.BackTracking
{
    public class CombinationSumOne
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var combinations = new List<IList<int>>();
            CombinationSumInternal(candidates, target, 0, new List<int>(), combinations);
            return combinations;
        }

        private void CombinationSumInternal(int[] candidates, int target, int current, IList<int> combination, IList<IList<int>> combinations)
        {
            if (target < 0) return;
            if(current >= candidates.Length) return;

            if(target == 0)
            {
                combinations.Add(new List<int>(combination));
                return;
            }

            for(int index = current; index < candidates.Length; index++)
            {
                combination.Add(candidates[index]);
                CombinationSumInternal(candidates, target-candidates[index], index, combination, combinations);
                combination.RemoveAt(combination.Count - 1);
            }

        }

       
    }
}

