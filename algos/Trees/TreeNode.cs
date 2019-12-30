namespace algos.Trees
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;
        }

        static (SinglyLinkedListNode larger, SinglyLinkedListNode smaller) MakeEqual(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {

            SinglyLinkedListNode current1 = head1;
            SinglyLinkedListNode current2 = head2;

            while (current1 != null && current2 != null)
            {
                current1 = current1.next;
                current2 = current2.next;
            }

            if (current1 == null && current2 == null)
            {
                return (head1, head2);
            }

            (SinglyLinkedListNode larger, SinglyLinkedListNode smaller)
           = current1 != null ? (head1, head2) : (head2, head1);

            var currentInLarger = current1 ?? current2;

            while (currentInLarger != null)
            {
                currentInLarger = currentInLarger.next;
                larger = larger.next;
            }

            return (larger, smaller);

        }

        static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            var (first, second) = MakeEqual(head1, head2);

            while (first != null && second != null)
            {
                if (first.next == second.next)
                {
                    return first.next.data;
                }

                first = first.next;
                second = second.next;

            }

            return int.MinValue;

        }
    }



}





