#include <iostream>

int main(){
    int n;
    scanf("%d", &n);
    int dp[n+1][10];
    
    dp[1][0] = 0;
    for(int i = 1; i < 10; i++){
        dp[1][i] = 1;
    }

    for(int i = 2; i <= n; i++){
        // 2차원 배열은 맨 뒷자리 번호
        dp[i][0] = dp[i-1][1] % 1000000000;
        dp[i][9] = dp[i-1][8] % 1000000000;
        for(int j = 1; j <= 8; j++){
            dp[i][j] = (dp[i-1][j-1] + dp[i-1][j+1]) % 1000000000;
        }
    }

    long long result = 0;
    for(int i = 0; i <= 9; i++){
        result += dp[n][i] % 1000000000;
    }
    printf("%lld", result % 1000000000);
}
