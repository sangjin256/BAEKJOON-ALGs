#include <iostream>
using namespace std;

int main(){
    int n;
    scanf("%d", &n);
    int dp[n+1][3];
    scanf("%d %d %d", &dp[1][0], &dp[1][1], &dp[1][2]);
    

    for(int i = 2; i <= n; i++){
        scanf("%d %d %d", &dp[i][0], &dp[i][1], &dp[i][2]);

        dp[i][0] = dp[i][0] + min(dp[i-1][1], dp[i-1][2]);
        dp[i][1] = dp[i][1] + min(dp[i-1][0], dp[i-1][2]);
        dp[i][2] = dp[i][2] + min(dp[i-1][0], dp[i-1][1]);
    }

    printf("%d", min(dp[n][0], min(dp[n][1],dp[n][2])));
}