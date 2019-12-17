using System.Collections.Generic;

namespace Trees{

    public class TreeNode<T>
    {
        public T Data {get; set;}
        public TreeNode<T> Left { get; set;}
        public TreeNode<T> Right { get; set;}
    }

    public class GenerateTree{

        public TreeNode<int> BuildTreeV2(int[] inOrder, int[] preOrder, 
        int inStart, int inEnd,
        int preStart, int preEnd){

            
            if(preStart > preEnd){
                return null;
            }
            

            var root = new TreeNode<int>(){
             Data = preOrder[preStart]   
            };

            if(preStart == preEnd){
                return root;
            }

            int countElementsInLeftTree = 0;            

            for(var rootValuePositionInOrder = inStart; rootValuePositionInOrder < inEnd; rootValuePositionInOrder++){

                if(inOrder[rootValuePositionInOrder] == root.Data){
                    break;
                }

                countElementsInLeftTree++;
            }

           var inOrderLeftEnd =   inStart + countElementsInLeftTree - 1;
           var preOrderLeftEnd =  preStart + countElementsInLeftTree;


           root.Left = BuildTreeV2(inOrder, preOrder, 
           inStart, inOrderLeftEnd,
           preStart + 1, preOrderLeftEnd);

         
           root.Right = BuildTreeV2(inOrder, preOrder, 
           inOrderLeftEnd + 2, inEnd,
           preOrderLeftEnd + 1, preEnd);
            

           return root;



        }

        public TreeNode<int> BuildTreeV2(int[] inOrder, int[] preOrder, 
        int inStart, int inEnd){
            return BuildTreeV2(inOrder, preOrder, inStart, inEnd, inStart, inEnd);
        }
        public TreeNode<int> BuildTree(int[] inOrder, int[] preOrder, int preStart, int inEnd){
            if(preStart > inEnd){
                return null;
            }

            var root = new TreeNode<int>(){
             Data = preOrder[preStart]   
            };

            var rootValuePositionInOrder = inEnd;

            for(; rootValuePositionInOrder > preStart; rootValuePositionInOrder--){

                if(inOrder[rootValuePositionInOrder] == root.Data){
                    break;
                }
            }

           root.Left = BuildTree(inOrder, preOrder, preStart + 1, rootValuePositionInOrder);
           root.Right = BuildTree(inOrder, preOrder, rootValuePositionInOrder + 1, inEnd);
            

            return root;
        }

        public int[] PrintPostOrder(TreeNode<int> root){
            List<int> data = new List<int>();
            if(root == null){
                return data.ToArray();
            }

            data.AddRange(PrintPostOrder(root.Left));
            data.AddRange(PrintPostOrder(root.Right));
            data.Add(root.Data);

            return data.ToArray();
        }


    }
    
}