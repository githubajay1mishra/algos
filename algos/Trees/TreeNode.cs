namespace Trees
{
    public class TreeNode<T>
    {
        public T Data {get; set;}
        public TreeNode<T> Left { get; set;}
        public TreeNode<T> Right { get; set;}
    }
}