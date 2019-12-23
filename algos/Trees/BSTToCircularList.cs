namespace algos.Trees{

// Definition for a Node.
public class Node 
{
    public int val;
    public Node left;
    public Node right;

    public Node() {}

    public Node(int _val) {
        val = _val;
        left = null;
        right = null;
    }

    public Node(int _val,Node _left,Node _right) {
        val = _val;
        left = _left;
        right = _right;
    }
}

public class BStToCircularSolution {

    private Node last;
    private Node first;
    
    public Node TreeToDoublyList(Node root) {
        // find minimum in the right tree 
       Helper(root);
       if(first != null){
          first.left = last;
          last.right = first; 
           
       } 
       
       return first;
         
    }
    
    private void Helper(Node node){
        if(node == null){
            return;
        }
        
        Helper(node.left);
        
        if(last != null){
            last.right = node;
            node.left = last;
            
        }else{
            first = node;
        }
        
        last = node;
        Helper(node.right);
    }

  

    

}

}
