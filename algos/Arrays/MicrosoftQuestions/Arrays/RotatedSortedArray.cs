using System;
using System.Diagnostics;

public class RotatedArray {
    
        public int Search(int[] nums, int target) {
        
        return SearchRotated(nums, target, 0, nums.Length -1);
    }

    public int SearchRotated(int[] nums, int target, int start, int end){
        Debug.WriteLine($"SearchRotated {start} {end}");

        
        if(start > end) return -1;

        if(start == end){
            return nums[start] == target ? start : -1;
        }


        if(nums[start] < nums[end] )
         return SearchSorted(nums, target, start, end);

 

        var mid =  (start + end) /2;

        var leftSorted =   nums[start] < nums[mid];
        var sortStart = leftSorted ? start : mid + 1;
        var sortEnd = leftSorted ? mid : end;
        
        if(nums[sortStart] <= target && nums[sortEnd] >= target){
            return SearchSorted(nums, target, sortStart, sortEnd);
        }

        var nextStart = leftSorted ? mid + 1 : start;
        var nextEnd = leftSorted ?  end : mid;


        return SearchRotated(nums, target,nextStart, nextEnd);

    }

    public int SearchSorted(int[] nums, int target, int start, int end){
        Debug.WriteLine($"SearchSorted {start} {end}");
        if(start > end)
        return -1;
        var mid = (start + end) /2;

        if(nums[mid] == target){
            return mid;
        }

        return target < nums[mid] ? SearchSorted(nums, target, start, mid - 1) 
        : SearchSorted(nums, target, mid + 1, end);

    }

    /*
     1 2 3 4 5 6 7 8 9
     5 6 7 8 9 1 2 3
     9 1 2 3 4 5 6 7 8
     6 7 8 9 1 2 3 5

    */

}