namespace algos.Strings
{

    public class RomanNumeralStringToAlgo
    {

        public int RomanToInt(string s)
        {

            if (string.IsNullOrEmpty(s))
            {
                return int.MinValue;
            }

            var lastCharacter = s[s.Length-1];
            var lastPositiveValue = GetValueFor(lastCharacter);
            var sum = lastPositiveValue;

            for (int index = s.Length - 2; index >= 0; index--)
            {
                var valueForCurrentCharacter = GetValueFor(s[index]);
                if(valueForCurrentCharacter < lastPositiveValue){
                    sum -= valueForCurrentCharacter;
                }else{
                    sum += valueForCurrentCharacter;
                    lastPositiveValue = valueForCurrentCharacter;
                }

            }

            return sum;

        }

        /*
            I             1
            V             5
            X             10
            L             50
            C             100
            D             500
            M             1000
        */

        private static int GetValueFor(char romanNumeralCharacter)
        {
            switch (romanNumeralCharacter)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;

            }
        }


        public (string term, int remainingValue) TryAddGeneric(int num, int convertValue, char romanChar, int subtractValue, char subtractChar)
        {
            string term = "";
            var remainingValue = num;
            if (num >= convertValue)
            {
                var repeatCount = num / convertValue;
                term = new string(romanChar, repeatCount);
                remainingValue = num % convertValue;
            }
            else if (num >= subtractValue)
            {
                term = string.Join("", subtractChar, romanChar);
                remainingValue = num - subtractValue;
            }


            return (term, remainingValue);

        }
        public string IntToRoman(int num)
        {
            var result = "";
            while(num > 0)
            {
               var resultM = TryAddGeneric(num, 1000, 'M', 900, 'C');
                if(resultM.term != "")
                {
                    result += resultM.term;
                    num = resultM.remainingValue;
                    continue;
                }

                var resultD = TryAddGeneric(num, 500, 'D', 400, 'C');
                if (resultD.term != "")
                {
                    result += resultD.term;
                    num = resultD.remainingValue;
                    continue;
                }

                var resultC = TryAddGeneric(num, 100, 'C', 90, 'X');
                if (resultC.term != "")
                {
                    result += resultC.term;
                    num = resultC.remainingValue;
                    continue;
                }

                var resultL = TryAddGeneric(num, 50, 'L', 40, 'X');
                if (resultL.term != "")
                {
                    result += resultL.term;
                    num = resultL.remainingValue;
                    continue;
                }

                var resultX = TryAddGeneric(num, 10, 'X', 9, 'I');
                if (resultX.term != "")
                {
                    result += resultX.term;
                    num = resultX.remainingValue;
                    continue;
                }

                var resultV = TryAddGeneric(num, 5, 'V', 4, 'I');
                if (resultV.term != "")
                {
                    result += resultV.term;
                    num = resultV.remainingValue;
                    continue;
                }

                result += new string('I', num / 1);
                num = 0;


            }

            return result;
        }

        
    

    }




}