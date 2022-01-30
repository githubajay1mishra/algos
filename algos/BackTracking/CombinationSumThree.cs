using System.Collections.Generic;

namespace algos.BackTracking
{
    public class CombinationSumThree 
    {
        
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            var results = new List<IList<int>>();
            CombinationSumInternal(k, n, new List<int>(), 1, results);
            return results;
            
        }
        private void CombinationSumInternal(int remainingLength, int remainingSum, IList<int> combination, int currentNumber, IList<IList<int>> result)
        {
            if (remainingLength < 0 || remainingSum < 0) { return; }

            if (remainingSum == 0)
            {
                if (remainingLength == 0)
                {
                    result.Add(new List<int>(combination));
                }

                return;
            }

            for (int i = currentNumber; i <= 9; i++)
            {
                combination.Add(i);
                CombinationSumInternal(remainingLength - 1, remainingSum - i, combination, i + 1, result);
                combination.RemoveAt(combination.Count - 1);
            }

        }
    }
}

