using System;
using System.Collections.Generic;

namespace algos.BackTracking
{
    public class CombinationSumTwo
    {

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {

            Array.Sort(candidates);
            var combinations = new List<IList<int>>();
            CombinationSumInternal(candidates, target, 0, new List<int>(), combinations);
            return combinations;
        }

        private void CombinationSumInternal(int[] candidates, int target, int current, IList<int> combination, IList<IList<int>> combinations)
        {


            if (target == 0)
            {

                combinations.Add(new List<int>(combination));

            }

            if (target < 0) return;
            if (current >= candidates.Length) return;

            for (int index = current; index < candidates.Length; index++)
            {
                if (index > current && candidates[index] == candidates[index - 1]) continue;
                combination.Add(candidates[index]);
                CombinationSumInternal(candidates, target - candidates[index], index + 1, combination, combinations);
                combination.RemoveAt(combination.Count - 1);
            }

        }


    }
}

