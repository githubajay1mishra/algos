using System;
using System.Collections.Generic;
using System.Linq;

namespace algos.Recursion{

    class SolutionSuperDigit {

         static int superDigit(string n, int k) {
        Console.WriteLine($"{n} {k}");
         
         List<long> digits = new List<long>();
         
         for(int index = 0; index < n.Length; index++){
                 digits.Add(long.Parse(n.Substring(index, 1)));         
         }        
         
                        
         return (int)superDigit(digits.Sum()*k);         
    }
    
     static long superDigit(long number) {
         if(number <= 9){
             return number;
         }
         
         return superDigit(number.ToString(), 1);
    }

    }

}