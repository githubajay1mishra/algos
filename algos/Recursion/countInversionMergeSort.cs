namespace algos.Recursion
{
    public class SolutionMergeSort
    {

        static long countInversions(int[] arr, int start, int end, int[] temp)
        {
            if (start >= end)
            {
                return 0;
            }

            long swaps = 0;

            var mid = (start + end) / 2;

            swaps += countInversions(arr, start, mid, temp);
            swaps += countInversions(arr, mid + 1, end, temp);

            for (int index = start; index <= end; index++)
            {
                temp[index] = arr[index];
            }

            var leftIndex = start;
            var rightIndex = mid + 1;
            var copyIndex = leftIndex;
            while (leftIndex <= mid && rightIndex <= end)
            {
                if (temp[leftIndex] <= temp[rightIndex])
                {
                    arr[copyIndex++] = temp[leftIndex++];
                }
                else
                {
                    swaps += (mid - leftIndex + 1);
                    arr[copyIndex++] = temp[rightIndex++];

                }

            }


            for (int index = leftIndex; index <= mid; index++)
            {
                arr[copyIndex] = temp[index];
                copyIndex++;
            }

            return swaps;
        }


        static long countInversions(int[] arr)
        {
            var temp = new int[arr.Length];

            var answer = countInversions(arr, 0, arr.Length - 1, temp);
            return answer;

        }
    }

}