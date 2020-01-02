using System;
namespace algos.DynamicProgrammng
{
    public class SolutionStringAbbreviationDP
    {

        static string abbreviationNonDP(string a, string b)
        {

            int indexA = 0;
            int indexB = 0;

            while (indexA < a.Length && indexB < b.Length)
            {
                char charA = a[indexA];
                char charB = b[indexB];

                if (charA == charB
                   ||
                   char.ToUpper(charA) == charB)
                {
                    indexA++;
                    indexB++;
                    continue;
                }

                if (char.IsUpper(charA))
                {
                    break;
                }

                indexA++;


            }

            while (indexA < a.Length)
            {
                if (char.IsUpper(a[indexA]))
                {

                    return "NO";
                }

                indexA++;
            }

            var result = indexB == b.Length ? "YES" : "NO";


            return result;

        }
    }

}