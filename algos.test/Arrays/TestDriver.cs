using algos.Arrays;
using Xunit;

public class ArraysTestDriver{

    [Fact]
    public void TestForSubArrayMatchesSum()
    {
        int[] input= {1, 2, 3, 7, 5,};
        Assert.Equal((2,4), SumSubArray.GetSubArrayThatMatchesSumDC(input, 12));

        int[] input2 = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        Assert.Equal((1,5), SumSubArray.GetSubArrayThatMatchesSumDC(input2, 15));
    
    }

    /*
    Input: [23, 2, 4, 6, 7],  k=6
Output: True
Explanation: Because [2, 4] is a continuous subarray of size 2 and sums up to 6.
Example 2:

Input: [23, 2, 6, 4, 7],  k=6
Output: True
Explanation: Because [23, 2, 6, 4, 7] is an continuous subarray of size 5 and sums up to 42.
    */

    [Fact]
    public void TestCheckSumMatchedNK(){
        int[] data = {23, 2, 4, 6, 7};
        Assert.True(SumSubArray.CheckSubarraySum(data, 5));

    }

        [Fact]
    public void TestForKadaneAlgo()
    {
        int[] input= {1, 2, 3, -2, 5};
        Assert.Equal(9, Kadane.KadaneAlgo(input));  

        int[] input2= {-1, -2, -3, -4};
        Assert.Equal(-1, Kadane.KadaneAlgo(input2));         
    
    }

    [Fact]
    public void TestMaxSubArray(){
        Assert.Equal(25, SumSubArray
        .CumulativeSum(new int[]{3, 7, 4, 6, 5}));

        Assert.Equal(25, SumSubArray
        .CumulativeSum(new int[]{15, -5, 4, 6, 5}));
    }

    [Fact]
    public void TestForKthAlgo()
    {
        int[] inputA= {2, 3, 6, 7, 9};
        int[] inputB= {1, 4, 8, 10};
        Assert.Equal(6, KthElement.KthElementInMergedArray(inputA, inputB, 5)); 

        inputA= new[]{1, 10, 10, 25, 40, 54, 79}; 
        inputB= new[]{15, 24, 27, 32, 33, 39, 48, 68, 82, 88, 90};
        Assert.Equal(79, KthElement.KthElementInMergedArray(inputA, inputB, 15));                   

        inputA= new[]{4,5,14,16,21,23,26,32,34,51,51,55,58,80,82,82,82,83,88,91,93,95,97}; 
        inputB= new[]{7,9,9,10,11,11,11,12,15,16,16,17,19,21,22,22,23,26,26,26,27,28,29,29,29,31,33,33,35,37,38,38,40,40,44,50,51,52,52,54,55,56,58,58,61,61,63,64,67,70,71,72,77,77,77,78,78,82,83,83,83,84,84,84,86,86,87,88,89,89,91,91,91,93,94,96,98,98,98,99,100,100};
        Assert.Equal(98, KthElement.KthElementInMergedArray(inputA, inputB, 102));                   

   
    }

       [Fact]
    public void TestSudokuSolver()
    {
        int[] inputA= {2, 3, 6, 7, 9};
        int[] inputB= {1, 4, 8, 10};
        Assert.Equal(6, KthElement.KthElementInMergedArray(inputA, inputB, 5)); 

        inputA= new[]{1, 10, 10, 25, 40, 54, 79}; 
        inputB= new[]{15, 24, 27, 32, 33, 39, 48, 68, 82, 88, 90};
        Assert.Equal(79, KthElement.KthElementInMergedArray(inputA, inputB, 15));                   

        inputA= new[]{4,5,14,16,21,23,26,32,34,51,51,55,58,80,82,82,82,83,88,91,93,95,97}; 
        inputB= new[]{7,9,9,10,11,11,11,12,15,16,16,17,19,21,22,22,23,26,26,26,27,28,29,29,29,31,33,33,35,37,38,38,40,40,44,50,51,52,52,54,55,56,58,58,61,61,63,64,67,70,71,72,77,77,77,78,78,82,83,83,83,84,84,84,86,86,87,88,89,89,91,91,91,93,94,96,98,98,98,99,100,100};
        Assert.Equal(98, KthElement.KthElementInMergedArray(inputA, inputB, 102));                   

   
    }




}