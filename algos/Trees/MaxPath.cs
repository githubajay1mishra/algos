using System;

namespace algos.Trees
{

    public class Solution 
    {
        public int MaxPathSum(TreeNode node) {
           int maxSum = int.MinValue; 
           DetermineMaxSum(node, ref maxSum);
           return maxSum;                   
        }

        public int DetermineMaxSum(TreeNode node, ref int maxSum){

             if(node == null){
                return 0;
            }

            var leftTreeSum = DetermineMaxSum(node.left, ref maxSum);
            if(leftTreeSum < 0){
                leftTreeSum = 0;
            }
            var rightTreeSum = DetermineMaxSum(node.right, ref maxSum);          

            if(rightTreeSum < 0){
                rightTreeSum = 0;
            }
            var sumWithChildren = node.val + leftTreeSum + rightTreeSum;
           
            if(sumWithChildren > maxSum){
                maxSum = sumWithChildren;
            }

            return node.val + System.Math.Max(leftTreeSum, rightTreeSum);

        }


    }
    
}

