using System.Collections.Generic;

namespace algos.Arrays.MicrosoftQuestions.Atoi
{

    public class Solution
    {
        public int MyAtoi(string str)
        {

            str = str.Trim();

            if(string.IsNullOrEmpty(str)
               ||
               '+' != str[0] 
               && '-' != str[0]
               && !char.IsDigit(str[0])){
                   return 0;
               }

            int startIndexForDigits = -1; 
            bool isNegative = false;  
            var firstNonSpaceChar = str[0];
            if('+' == firstNonSpaceChar ||
                '-' == firstNonSpaceChar){
              startIndexForDigits = 1;
              isNegative = '-' == firstNonSpaceChar;
              
            }

            if(char.IsDigit(firstNonSpaceChar)){
                startIndexForDigits = 0;
            } 

            bool parsedDigit = false;
            long valueToReturn = 0;


            for(int index = startIndexForDigits; index <= str.Length - 1; ++index){
                var curCurrent = str[index];
                if(!char.IsDigit(curCurrent)){

                    if(parsedDigit){
                        break;
                    }
                }

                parsedDigit = true;
                
                var integralValueForCurrentDigit = curCurrent-48;

                valueToReturn = valueToReturn * 10 + integralValueForCurrentDigit;
                
                if(isNegative){
                      if( (-1)* valueToReturn < int.MinValue){
                        return int.MinValue;
                      }
                   
                }else {
                    if(  valueToReturn > int.MaxValue){
                        return int.MaxValue;
                      }
                }
            }

            return  (isNegative ? (-1) * (int) valueToReturn
            : (int) valueToReturn);                

        }

         
    }


}