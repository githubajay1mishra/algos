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

    }




}