public class CountValleys
{
    static int countingValleys(int n, string s) {
        int countValley = 0;

        int levelAboveSea = 0;
        for(int step =0; step < n; step++) {
            if(s[step] == 'U'){
                ++levelAboveSea; 
                
                if(levelAboveSea == 0){
                    ++countValley;
                }
            }else{
                --levelAboveSea;
            }

        }

        return ++countValley;
    }
    
}