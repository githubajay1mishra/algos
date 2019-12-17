using System;
namespace algos.Trees
{
    
     public class IsValidBstSolution
     {

         public bool IsValidBST(TreeNode root) 
         {
             
             return isInRange(root, long.MinValue, long.MaxValue);

         }

         private bool isInRange(TreeNode node, long min, long max){
             if(node == null){
                 return true;
             }

             var isNodeValueInRange = node.val > min && node.val < max;
             if(!isNodeValueInRange){
                 return false;
             }

             var leftTreeIsValidBinary = isInRange(node.left, min, node.val);

             if(!leftTreeIsValidBinary){
                 return false;
             }

             var rightTreeIsValidBinary = isInRange(node.right, node.val, max);

             if(!rightTreeIsValidBinary){
                 return false;
             }

             return true;                          
         }
        
    

     }


}