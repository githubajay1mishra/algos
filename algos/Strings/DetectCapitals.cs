using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace algos.Strings
{
    public class DetectCapitals
    {   
        public bool DetectCapitalUse(string word)
        {
            return  word.All(character => char.IsLower(character))
                                ||
                                word.All(character => char.IsUpper(character))
                                ||
                                word.Skip(1).All(character => char.IsLower(character));

        }

    }
}
