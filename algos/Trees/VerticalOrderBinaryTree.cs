using System;
using System.Collections.Generic;

namespace algos.Trees
{

    public class SolutionPrintVerticalTree
    {
        public IList<IList<int>> VerticalOrder(TreeNode root)
    {
        var output = new List<IList<int>>();
        if(root == null)
        {
            return output;        
        }
        
        Queue<Tuple<int, TreeNode>> bfs = new Queue<Tuple<int, TreeNode>>();
        Tuple<int, TreeNode> colindexanddata = Tuple.Create(0, root);
        bfs.Enqueue(colindexanddata);
        Dictionary<int, List<int>> colIndexVsData = new Dictionary<int, List<int>>();
        int mincolumnindex = 0;
        int maxcolumnindex = 0;
        
        while(bfs.Count > 0)
        {
           var tuple = bfs.Dequeue();
           var colIndex = tuple.Item1;
           var currentNode = tuple.Item2; 
            
           if(colIndex < mincolumnindex)
           {
               mincolumnindex = colIndex;
           } 
            
           if(colIndex > maxcolumnindex)
           {
               maxcolumnindex = colIndex;
           }
            
            
           if(colIndexVsData.ContainsKey(colIndex))
           {
               colIndexVsData[colIndex].Add(currentNode.val);           
           }
           else
           {
               colIndexVsData[colIndex] = new List<int>()
               {
                   currentNode.val
               };           
           }         
           
           if(currentNode.left != null)
           {
              var leftChildInfo = Tuple.Create(colIndex - 1, currentNode.left);
              bfs.Enqueue(leftChildInfo);
           }
           
           if(currentNode.right != null)
           {
               var rightChildInfo = Tuple.Create(colIndex + 1, currentNode.right);
              bfs.Enqueue(rightChildInfo);
                          
           }          
             
            
            
        }
        
        
        for(int index = mincolumnindex; index <= maxcolumnindex; ++index)
        {
            
            output.Add(colIndexVsData[index]);
        }
        
        return (IList<IList<int>>)output;       
           
        
    
    }
    }
    
}