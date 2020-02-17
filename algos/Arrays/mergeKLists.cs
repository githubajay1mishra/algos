namespace algos.Arrays
{
    public class SolutionMergeKLists
    {

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }

        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode head = null;
            ListNode currentEnd = null;

            var minimum = GetNextNode(lists);
            while (null != minimum)
            {
                if (head == null)
                {
                    head = minimum;
                    currentEnd = minimum;
                }
                else
                {
                    currentEnd.next = minimum;
                    currentEnd = minimum;
                }

                minimum = GetNextNode(lists);
            }


            return head;

        }

        public ListNode GetNextNode(ListNode[] lists)
        {

            int listWithMinimum = -1;
            int minimumValue = int.MaxValue;

            for (int index = 0; index < lists.Length; index++)
            {

                if (lists[index] != null
                  &&
                  lists[index].val <= minimumValue)
                {
                    listWithMinimum = index;
                    minimumValue = lists[index].val;
                }
            }

            if (listWithMinimum < 0)
            {
                return null;
            }

            ListNode minimum = lists[listWithMinimum];
            lists[listWithMinimum] = minimum.next;

            return minimum;
        }



    }

}
