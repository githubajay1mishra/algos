using System.Diagnostics;
using System.Text;

public class MorganStringAlgo{

     private static  bool shouldTakeJackOnTie(string jack, 
        string daniel, int jackNextIndex, int danielNextIndex){

            
            if(jackNextIndex < jack.Length && danielNextIndex < daniel.Length){
                if(jack[jackNextIndex] == daniel[danielNextIndex]){
                    return shouldTakeJackOnTie(jack, 
                    daniel, jackNextIndex + 1, 
                    danielNextIndex + 1);
                }

                return jack[jackNextIndex] < daniel[danielNextIndex];
            } 

            return (jackNextIndex < jack.Length) ? true : false;

        }
       

      public static string morganAndString(string jack, string daniel) {
        var nextJackCharIndex = 0;
        var nextDanielCharIndex = 0;

        StringBuilder morganStringBuilder = new StringBuilder();

        while(true){
            var characterFromJack = jack[nextJackCharIndex];
            var characterFromDaniel = daniel[nextDanielCharIndex];

            bool takeFromJack = false;
            
            if(characterFromJack < characterFromDaniel)
            {
                takeFromJack = true;
            } else if(characterFromDaniel == characterFromJack){
                             

                takeFromJack = shouldTakeJackOnTie(jack, daniel, nextJackCharIndex + 1,
                nextDanielCharIndex + 1);
                // Debug.WriteLine($"Inserting at position {morganStringBuilder.Length - 1}");
                // Debug.WriteLine($"Took Jack:{takeFromJack}");
                // var jackEvidence = nextJackCharIndex + 5 < jack.Length - 1 
                // ? jack.Substring(nextJackCharIndex, 5) 
                // : jack.Substring(nextJackCharIndex);
                // var danEvidence = nextDanielCharIndex + 5 < daniel.Length - 1 
                // ? daniel.Substring(nextDanielCharIndex, 5) 
                // : daniel.Substring(nextDanielCharIndex);
                // Debug.WriteLine($"Jack:{jackEvidence}");
                // Debug.WriteLine($"Dani:{danEvidence}");
                
                
              }

            if(takeFromJack){
                morganStringBuilder.Append(characterFromJack);
                nextJackCharIndex++;
            }
           
            else{
                 morganStringBuilder.Append(characterFromDaniel);
                nextDanielCharIndex++;
            }

            

            var areAllCharactersFromJackProcessed = nextJackCharIndex == jack.Length;
            if(areAllCharactersFromJackProcessed){
                morganStringBuilder.Append(daniel.Substring(nextDanielCharIndex));
                break;
            }

            var areAllCharactersFromDanielProcessed = nextDanielCharIndex == daniel.Length;
            if(areAllCharactersFromDanielProcessed){
                morganStringBuilder.Append(jack.Substring(nextJackCharIndex));
                 break;
            }


        }

        return morganStringBuilder.ToString();


    }

}