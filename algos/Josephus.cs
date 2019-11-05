using System;
using System.Linq;

namespace algos
{
    public class Josephus
    {
        public static int FindSafestPosition(int n, int k)
        {
            
            // var sumDisplacement = ((n-1)*(n-2))/2;
          // return ((n-1)*k + 1) % n +1;
          return ((n-1)* k + (n - 1)) % n ; 
        }
        public static int[] parseInputAndGetOutput(string[] testCaseData){
        
             int[] output = new int[testCaseData.Length];

            

            for(int testCaseIndex = 0; testCaseIndex < testCaseData.Length; ++testCaseIndex){
                 var testCaseString = testCaseData[testCaseIndex].Split(' ');
                 output[testCaseIndex] = FindSafestPosition(int.Parse(testCaseString[0]), 
                                                            int.Parse(testCaseString[1]));
            }

           return output;
        }
        public static void main(string[] args){
            var numberOfTestCases = int.Parse(Console.ReadLine());
             var testCaseData = new string[numberOfTestCases];
            for(int i = 0; i < numberOfTestCases; i++){
                testCaseData[i] = Console.ReadLine();                      
            }

            int[] output = parseInputAndGetOutput(testCaseData);

            for(int i = 0; i < numberOfTestCases; ++i){
                Console.WriteLine(output[i]);
            }
        }

    }
}
