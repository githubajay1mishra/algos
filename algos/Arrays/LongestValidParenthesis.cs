using System;
using System.Collections.Generic;

namespace algos.Arrays
{
    public class LongestValidParenthesis
    {
        public int GetLongestValidParenthesisLength(string s){
          int length = 0;

          int left = 0;
          int right = 0;

          for(int index = 0; index < s.Length; index++){

              if(s[index] == '(') {
                  left++;
              }else {
                  right++;
              };

              if(left == right){
                  length = Math.Max(length, left + right);
              }

              if(left < right){
                  left = right = 0;
              }
          }

          
          left = 0;
          right = 0;

          for(int index = s.Length-1; index >= 0; index--){

              if(s[index] == '(') {
                  left++;
              }else {
                  right++;
              };

              if(left == right){
                  length = Math.Max(length, left + right);
              }

              if(right < left){
                  left = right = 0;
              }
          }

          return length;

        }


    }
}
