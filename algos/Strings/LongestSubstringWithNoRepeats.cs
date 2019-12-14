using System;
using System.Collections.Generic;

namespace algos.Strings
{

    public class LongestSubstringWithNoRepeats
    {

        public static int FindLongestSubstringWithNonRepeatingCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            int lengthLargestSubString = 1;

            int lengthCurrentSubString = 1;
            var uniqueCharacterListCurrentSubString = new Dictionary<char, int>();
            uniqueCharacterListCurrentSubString.Add(input[0], 0);
            var startIndexCurrentSubstring = 0;


            for (int index = 1; index < input.Length; index++)
            {
                var currentChar = input[index];

                if (!uniqueCharacterListCurrentSubString.ContainsKey(currentChar))
                {
                    uniqueCharacterListCurrentSubString.Add(currentChar, index);
                    lengthCurrentSubString++;

                    if (lengthCurrentSubString > lengthLargestSubString)
                    {
                        lengthLargestSubString = lengthCurrentSubString;
                    }

                    continue;

                }

                var lastIndexOfCharacter = uniqueCharacterListCurrentSubString[currentChar];
                uniqueCharacterListCurrentSubString[currentChar] = index;

                if (lastIndexOfCharacter < startIndexCurrentSubstring)
                {
                    lengthCurrentSubString++;
                }
                else
                {
                    startIndexCurrentSubstring = lastIndexOfCharacter + 1;
                    lengthCurrentSubString = index - startIndexCurrentSubstring + 1;


                }


                if (lengthCurrentSubString > lengthLargestSubString)
                {
                    lengthLargestSubString = lengthCurrentSubString;
                }
            }

            return lengthLargestSubString;

        }


    }
}