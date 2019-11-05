namespace MicrosoftQuestions.Arrays.IsPalindrome
{
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            int rightIndex = s.Length;
            var stringToCheck = FilterCharactersAndConvertToLowerIfNeeded(s);
            var numberCharactersToCheck = stringToCheck.Length / 2;
            for (int index = 0; index < numberCharactersToCheck; ++index)
            {
                var leftChar = stringToCheck[index];
                var rightChar = stringToCheck[stringToCheck.Length - 1 - index];
                if (leftChar != rightChar)
                {
                    return false;
                }
            }

            return true;
        }

        private string FilterCharactersAndConvertToLowerIfNeeded(string s)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    sb.Append(c);
                }
                if (char.IsLetter(c))
                {
                    sb.Append(char.ToLower(c));
                }
            }
            return sb.ToString();
        }
    }

}