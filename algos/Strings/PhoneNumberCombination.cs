using System;
using System.Collections.Generic;

namespace algos.Strings
{
    public class PhoneNumberCombination
    {
        public IList<string> ListCombination(string digits){
            return ListCombination(digits, 0, new List<char>());
        }

        public IList<string> ListCombination(string digits, int index, List<char> sequence){

            var result = new List<string>();

            if(index > digits.Length - 1){

                var comb = new string(sequence.ToArray());
                result.Add(comb);
                return result;

            }

            
            var chars = CharsForDigit(digits[index]);

            foreach(char alphabet in chars)
            {
                sequence.Add(alphabet);
                result.AddRange(ListCombination(digits, index + 1, sequence));
                sequence.RemoveAt(sequence.Count - 1);
            }            

            return result;
        }

        public char[] CharsForDigit(char digit){

            switch (digit)
            {
                case '2':
            return new char[]{'a', 'b', 'c'};
            
            case '3':
            return new char[]{'d', 'e', 'f'};

            
            case '4':
            return new char[]{'g', 'h', 'i'};

            
            case '5':
            return new char[]{'j', 'k', 'l'};

            
            case '6':
            return new char[]{'m', 'n', 'o'};

            
            case '7':
            return new char[]{'p', 'q', 'r', 's'};

            
            case '8':
            return new char[]{'t', 'u', 'v'};

            
            case '9':
            return new char[]{'w', 'x', 'y', 'z'};

            
            default:
            return new char[]{'a', 'b', 'c'};
            }
            
            


        }
    
    }
}
