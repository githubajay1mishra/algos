namespace algos.DynamicProgrammng
{

    public class LongestPalindromeSolution{

        public string LongestPalindrome(string s) {
            if(string.IsNullOrEmpty(s)){
                return s;
            }

            var start = 0;
            var length = 1;

            for(int index = 0; index < s.Length; ++index){

                var (length1, start1) = GetLongestPalindromeAroungCenter(s, index, index);
                if(length1 > length){
                    length = length1;
                    start = start1;
                }

                var (length2, start2) = GetLongestPalindromeAroungCenter(s, index, index + 1);

                 if(length2 > length){
                    length = length2;
                    start = start2;
                }
            }

            return s.Substring(start, length);
        }

        private (int length, int start) GetLongestPalindromeAroungCenter(string s, int left, int right){
            var start =  -1;
            var length = 0;

            while(left >= 0  && right < s.Length && s[left] == s[right]){
                length = right - left + 1;
                start = left;
                --left;
                ++right;
            }

            return (length, start);
        }


    }
    
}