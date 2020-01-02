using System;
namespace algos.Arrays
{
    public class SolutionBribesMinimumSwaps
    {
        public static void minimumSwaps(int[] q)
        {            
            bool chaotic = false;            
            int jumpAheadCount = 0;
            
            for (var index = q.Length - 1; index >= 0; index--)
            {
                var element = index + 1;
                var jumps = countJumpAheads(q, element);
                if (jumps < 0)
                {
                    chaotic = true;
                    break;
                }

                swap(q, element, jumps);
                jumpAheadCount += jumps;
            }

            var result = chaotic ? "Too chaotic" : jumpAheadCount.ToString();
            Console.WriteLine(result);

        }

        static int countJumpAheads(int[] q, int element)
        {
            var startPosition = element - 1;
            var minPossiblePosition = startPosition - 2 < 0 ? 0 : startPosition - 2;
            var jumpCount = -1;

            for (int index = minPossiblePosition; index <= startPosition; ++index)
            {

                if (q[index] == element)
                {

                    jumpCount = startPosition - index;

                }

            }

            return jumpCount;
        }

        static void swap(int[] q, int element, int swapCount)
        {


            while (swapCount > 0)
            {
                var swapIndex = element - 1 - swapCount;
                var temp = q[swapIndex];
                q[swapIndex] = q[swapIndex + 1];
                q[swapIndex + 1] = temp;
                swapCount--;
            }
        }



    }

}