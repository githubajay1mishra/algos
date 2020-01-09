using System;
using System.Collections.Generic;
using System.Linq;
namespace algos.Trees
{

    public class SolutionSwapNodes
    {
      static void Main(string[] args)
    {
        for (var i = 0; i < 5; i++)
        {
            Console.WriteLine("Hello, World");
        }
    }
    
    static int[][] swapNodes(int[][] indexes, int[] queries) {
        /*
         * Write your code here.
         */
        var root = new TreeNode(){
           Depth = 1,
           Number = 1            
        };
        
        for(int position = 1; position <= indexes.Length; position++)
        {
            var children = indexes[position - 1];
            var  parent = TreeNode.GetTreeNodeAtPosition(position, root);
            
            if(children[0] != -1){
                parent.Left = new TreeNode(){
                    Number = children[0],                    
                    Depth = parent.Depth + 1
                };                
            }
            
            if(children[1] != -1){
                parent.Right = new TreeNode(){
                    Number = children[1],                    
                    Depth = parent.Depth + 1
                };                
            }
            
        }
        
        var result= new int[queries.Length][];      
        var index = 0;
        foreach(var k in queries){
            List<int> swapResult = new List<int>();
            TreeNode.Swap(root, k);
            TreeNode.InOrderTraversal(root, swapResult);
            result[index++] = swapResult.ToArray();            
        }
        
        return result;

    }
    
    public class TreeNode
    {
        public TreeNode Left {get;set;}
        public TreeNode Right {get;set;}
        public int Depth {get;set;}
        public int Number {get;set;}
        
        public static TreeNode GetTreeNodeAtPosition(int position, TreeNode node){
            
            if(node == null){
                return null;
            }
            
            
            if(node.Number == position){
                return node;
            }
            
            return GetTreeNodeAtPosition(position, node.Left) ?? GetTreeNodeAtPosition(position, node.Right);
        }
        
        
        public static void InOrderTraversal(TreeNode node, List<int> result){
            if(node == null){
                return;
            }          
            
            InOrderTraversal(node.Left, result);
            result.Add(node.Number);
            InOrderTraversal(node.Right, result);            
        }
        
        public static void Swap(TreeNode node, int k){
            if(node == null){
                return;
            }          
            
            if(node.Depth % k == 0){
                var temp = node.Left;
                node.Left = node.Right;
                node.Right = temp;
            }
            
            Swap(node.Left, k);
            Swap(node.Right, k);            
        }
        
        
    }

    }


}