using System;
using System.Collections.Generic;
using System.Linq;

namespace algos.Arrays
{

    public class KthElement
    {

        public static void Main(string[] args)
        {
            var numberOfTestCases = int.Parse(Console.ReadLine().Trim());
            // Console.WriteLine($"Number of testcases {numberOfTestCases}");
            for (int i = 0; i < numberOfTestCases; i++)
            {

                var sizesAndKInput = Console.ReadLine().Trim().Split(' ');
                var k = int.Parse(sizesAndKInput[2]);
                // Console.WriteLine($"Length:{length}");
                var dataArrayA = Console.ReadLine().Trim().Split(' ')
                               .Select(x => int.Parse(x))
                               .ToArray();

                var dataArrayB = Console.ReadLine().Trim().Split(' ')
                             .Select(x => int.Parse(x))
                             .ToArray();
                // Console.WriteLine($"Parsed data:{dataArray.Length} Sum:{string.Join(",", dataArray.Select(x => x.ToString())) }");

                Console.WriteLine($"{KthElementInMergedArray(dataArrayA, dataArrayB, k)}");
            }



        }

        public static int KthElementInMergedArray(int[] arrayA, int[] arrayB, int k)
        {
            var elementsToDropLeft = k - 1;
            var elementsToDropOnRight = arrayA.Length + arrayB.Length - k - 2;

            int aStart = 0;
            int aEnd = k < arrayA.Length ? k - 1 : arrayA.Length - 1;
            int bStart = 0;
            int bEnd = k < arrayB.Length ? k - 1 : arrayB.Length - 1;

            return GetKthElement(arrayA, aStart, aEnd, arrayB, bStart, bEnd, elementsToDropLeft);

        }

        private static int GetKthElement(int[] arrayA, int aStart, int aEnd,
                                  int[] arrayB, int bStart, int bEnd,
                                  int elementsToDropLeft)
        {
            if (aEnd < aStart)
            {
                return arrayB[bStart + elementsToDropLeft];
            }

            if (bEnd < bStart)
            {
                return arrayA[aStart + elementsToDropLeft];
            }

            if(elementsToDropLeft == 0){
                return arrayA[aStart] <= arrayB[bStart] ? arrayA[aStart] : arrayB[bStart]; 
            }

            int lengthRemainingA = elementsToDropLeft < aEnd - aStart + 1 ? elementsToDropLeft : aEnd - aStart + 1;
            int lengthRemainingB = elementsToDropLeft < bEnd - bStart + 1 ? elementsToDropLeft : bEnd - bStart + 1;

            var aPivot = aStart + (lengthRemainingA-1)/2;
            var bPivot = bStart + (lengthRemainingB-1)/2;


            if (arrayA[aPivot] < arrayB[bPivot])
            {
                 var elementsDroppedA = aPivot - aStart + 1;
                return GetKthElement(arrayA, aPivot + 1, aEnd, arrayB, bStart, bEnd,
                elementsToDropLeft - elementsDroppedA);

            }

            var elementsDroppedB = bPivot - bStart + 1;
            return GetKthElement(arrayA, aStart, aEnd, arrayB, bPivot + 1,
            bEnd,
            elementsToDropLeft - elementsDroppedB);



        }


    }

}


