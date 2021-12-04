using System;

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

        public static void Sort(int[] data){
      var helper = new int[data.Length];
      for(int index  = 0; index < data.Length; index++){
        helper[index] = data[index];
      }
      
       MergeSort(data, helper, 0, data.Length - 1);
    }
  
    public static void MergeSort(int[] data, int[] helper, int start, int end){
       Console.WriteLine(start + " " + end);

       if(start < end)
       {
         var mid = (start + end)/ 2;
         MergeSort(data, helper, start, mid);
         MergeSort(data, helper, mid+1, end); 
         Merge(data, helper, start, end);  
       }
         
         
       
      
    }
    
    public static void Merge(int[] data, int[] helper, int start, int end){
      for(int index  = start; index <= end; index++){
        helper[index] = data[index];
      }
      
      var left = start;
      var mid = (start + end) / 2;
      var right = mid + 1;
      var current  = left;
      
      while(current <= mid && current <=right){
        var swap = ShouldSwap(helper[left], helper[right]);
        if(!swap){
          data[current] = helper[left];
          left++;
        }else{
          data[current] = helper[right];
          right++;
        }
        current++;
      }
      
      for(int x = left; x <= mid; x++){
        data[current] = helper[x];
        current++;
      }      
      
      
    }
  
    static bool ShouldSwap(int x, int y){
      if(Math.Abs(x) != Math.Abs(y)){
        return Math.Abs(y) < Math.Abs(x); 
      }
      
      return y < x;
    }
    }

}