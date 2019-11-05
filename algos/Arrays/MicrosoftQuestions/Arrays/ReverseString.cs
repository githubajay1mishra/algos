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
using System.Collections.Generic;

namespace algos.Arrays.MicrosoftQuestions.ReverString
{

    public class Solution
    {

        public string ReverseWords(string s)
        {
            s = s.Trim();
            var index = s.Length - 1;
            bool insideAWord = false;
            StringBuilder sb = new StringBuilder();

            List<char> currentWordReversed = new List<char>();

            while (index >= 0)
            {
                char curChar = s[index];
                if (curChar != ' ')
                {
                    //sb.Insert(insertAtIndex, curChar);
                    currentWordReversed.Add(curChar);
                    insideAWord = true;
                }
                else
                {
                    if (insideAWord)
                    {
                        AddCurrentWordToStream(sb, currentWordReversed);

                        sb.Append(curChar);


                        currentWordReversed = new List<char>();

                        insideAWord = false;
                    }
                }

                --index;
            }

            if (currentWordReversed.Count > 0)
            {
                AddCurrentWordToStream(sb, currentWordReversed);
            }

            return sb.ToString();
        }

        private void AddCurrentWordToStream(StringBuilder sb, List<char> currentWordReversed)
        {
            for (int indexInCurrentWord = currentWordReversed.Count - 1; indexInCurrentWord >= 0; indexInCurrentWord--)
            {
                sb.Append(currentWordReversed[indexInCurrentWord]);
            }
        }



    }



}