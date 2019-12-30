using System;
using System.Collections.Generic;

namespace algos.Strings
{
    class SolutionCountSpecialString
    {

        // Complete the substrCount function below.
        class RepeatingCharacterInfo
        {
            public char Character { get; set; }
            public int Count { get; set; }

        }
        /*
        a b c b a b a
        1 1 1 1 1 1 1  
        */
        static long substrCount(int n, string s)
        {

            

            var repeatingInfoList = GetRepeatingCharacterInfo(s);

            return CountCombinationsBasedOnRepeatCount(repeatingInfoList)
                   +
                   CountCombinationsBasedForSingleLengthMiddleBlocks(repeatingInfoList);
        }

        static int CountCombinationsBasedOnRepeatCount(List<RepeatingCharacterInfo> infoList){
            var count = 0;
            foreach(var info in infoList){
                var combinationCount = (info.Count * (info.Count + 1))/2;
                count += combinationCount;
            }

            return count;
        }

        static int CountCombinationsBasedForSingleLengthMiddleBlocks(List<RepeatingCharacterInfo> infoList){
            var count = 0;
            for(var index = 1; index < infoList.Count - 1; ++index){
                 var curInfo = infoList[index];
                 var prevInfo = infoList[index - 1];
                 var nextInfo = infoList[index + 1];
                 if(curInfo.Count == 1
                    &&
                    prevInfo.Character == nextInfo.Character){
                        var characterOnEachSide = Math.Min(nextInfo.Count, prevInfo.Count);
                        var combinationCount = characterOnEachSide;
                        count += combinationCount;
                    }

            }
            
            return count;
        }

        static List<RepeatingCharacterInfo> GetRepeatingCharacterInfo(string s)
        {
            List<RepeatingCharacterInfo> infoList = new List<RepeatingCharacterInfo>();

            if (string.IsNullOrEmpty(s))
            {
                return infoList;
            }

            infoList.Add(new RepeatingCharacterInfo()
            {
                Character = s[0],
                Count = 1
            });

            for (int index = 1; index < s.Length; index++)
            {
                if (s[index - 1] == s[index])
                {
                    infoList[infoList.Count - 1].Count
                        = infoList[infoList.Count - 1].Count + 1;

                }
                else
                {

                    infoList.Add(new RepeatingCharacterInfo()
                    {
                        Character = s[index],
                        Count = 1
                    });

                }
            }

            return infoList;

        }


    }

}