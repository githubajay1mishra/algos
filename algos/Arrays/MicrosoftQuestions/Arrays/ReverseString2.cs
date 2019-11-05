// Given an input string, reverse the string word by word.


// Example 1:

// Input: "the sky is blue"
// Output: "blue is sky the"
// Example 2:

// Input: "  hello world!  "
// Output: "world! hello"
// Explanation: Your reversed string should not contain leading or trailing spaces.
// Example 3:

// Input: "a good   example"
// Output: "example good a"
// Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.


// Note:

// A word is defined as a sequence of non-space characters.
// Input string may contain leading or trailing spaces. However, your reversed string should not contain leading or trailing spaces.
// You need to reduce multiple spaces between two words to a single space in the reversed string.

using System.Text;

namespace algos.Arrays.MicrosoftQuestions.ReverseString.NoExtraSpace
{

    public class Solution
    {

        public void ReverseWords(char[] s)
        {
            int currentIndex = 0;
            int wordStart = 0;

            while(currentIndex < s.Length){
                if(currentIndex == s.Length-1
                   ||
                   s[currentIndex + 1] == ' '){
                      Reverse(s, wordStart, currentIndex);
                      wordStart += 2; 
                   }

                   currentIndex++;
            }

            Reverse(s, 0, s.Length-1);
        }

        public void Reverse(char[] s, int left, int right){
            while(left < right){
                var temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left ++;
                right --;
            }


            // var wordLength = wordStart - wordEnd + 1;
            // var numberOfSwaps = wordLength / 2;
            // for(int swapIndex = 0; swapIndex < numberOfSwaps; ++swapIndex){
            //     var startIndexToSwap = wordStart + swapIndex;
            //     var endIndexToSwap = wordEnd - swapIndex;
            //     var temp = s[startIndexToSwap];
            //     s[startIndexToSwap] = s[endIndexToSwap];
            //     s[endIndexToSwap] = temp;
            // }
        }

    }



}