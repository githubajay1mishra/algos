namespace algos.Trees
{
    public class LCASolution {
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null)
        {
            return null;
        }
        
        var ancestorInLeft = LowestCommonAncestor(root.left,   p, q);
        var ancestorInRight = LowestCommonAncestor(root.right, p, q);
        
        if(ancestorInLeft != null && ancestorInRight != null)
        {
            return root;
        }
        
        if(root.val == p.val || root.val == q.val){
           return root;
        }        
        
        
        return ancestorInLeft ?? ancestorInRight;          
        
        
    }
    

    
    
    public TreeNode LowestCommonAncestorMissingNode(TreeNode root, TreeNode p, TreeNode q) {
        isAncestor(root, p, q);
         
        return this.answer;
    
    }
    
    private bool isAncestor(TreeNode root, TreeNode p, TreeNode q){
       
        if(root == null) return false;
        
        var isAncestorInLeft = isAncestor(root.left, p, q);
        var isAncestorInRight = isAncestor(root.right, p, q);
        
        
        
        if(isAncestorInLeft && isAncestorInRight){
           this.answer = root;
           return true; 
        }
        
        
        var currentIsAncestor = root.val == p.val || root.val == q.val;
                
        
        if(currentIsAncestor && (isAncestorInLeft || isAncestorInRight)){
           this.answer = root;
            return true;
        }
        
        return currentIsAncestor || isAncestorInLeft || isAncestorInRight;
    
    }
    
    
    TreeNode answer = null;
    
    
    
    
    
    
}
    
}