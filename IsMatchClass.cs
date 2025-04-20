public class Solution {
    public bool IsMatch(string s, string p){
        if(s == p){
            return true;
        }

        if(string.IsNullOrEmpty(p)){
            return false;
        }
        int sp = 0, pp = 0;
        int sStar = -1, pStar = -1;
        while(sp < s.Length){
            if(pp < p.Length && (s[sp] == p[pp] || p[pp] == '?')){
                sp++;
                pp++;
            }
            else if(pp < p.Length && p[pp] == '*'){
                pStar = pp;
                sStar = sp;
                pp++;
            }
            else if(pStar == -1){
                return false;
            }
            else{
                pp = pStar;
                sp = sStar;
                pp++;
                sp++;
                sStar = sp;
            }
        }
        while(pp < p.Length){
            if(p[pp] != '*'){
                return false;
            }
            pp++;
        }
        return true;
    }
    // TC => O(m*n)
    // SC => O(m*n)
    public bool IsMatch1(string s, string p) {
        if(s == p){
            return true;
        }

        if(string.IsNullOrEmpty(p)){
            return false;
        }

        int m = p.Length;
        int n = s.Length;

        bool[][] dp = new bool[m+1][];
        for(int i = 0; i< m+1; i++){
            dp[i] = new bool[n+1];
        }
        dp[0][0] = true;

        for(int i = 1; i< m+1;i++){
            for(int j = 0; j < n+1; j++){
                if(p[i-1] != '*'){
                    if(j > 0 && (p[i-1] == s[j-1] || p[i-1] == '?')){
                        dp[i][j] = dp[i-1][j-1];
                    }
                }
                else{
                    dp[i][j] = dp[i-1][j];
                    if(j > 0){
                        dp[i][j] = dp[i][j]|| dp[i][j-1];
                    }
                }
            }
        }
        return dp[m][n];
    }
}