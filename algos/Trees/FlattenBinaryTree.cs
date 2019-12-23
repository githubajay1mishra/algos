using System;

namespace algos.Trees
{
    public class FlattenBinaryTreeSolution
    {
        
        public void Flatten(TreeNode root)
        {
            TreeNode last = null;
            PreOrderTraversal(root, ref last);
            var current = root;
            while(current.left != null){
                current.right = current.left;
                current.left  = null;
                current = current.right;
            }            
        }

        private void PreOrderTraversal(TreeNode node, ref TreeNode last){
            if(node == null){
                return;
            }

            if(last != null){
                Console.WriteLine($"assigned {node.val} to left of {last.val}");
                last.left = node;
            }
            last = node;

            PreOrderTraversal(node.left, ref last);
            PreOrderTraversal(node.right, ref last);

        }
    }

}