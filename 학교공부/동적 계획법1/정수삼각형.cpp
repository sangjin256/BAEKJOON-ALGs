#include <iostream>

int main(){
    // triangle[n][]은 층
    // triangle[][n]은 그 층의 수
    int n;
    scanf("%d", &n);
    int triangle[n+1][n+1], dp[n+1][n+1];

    for(int i = 1; i <= n; i++){
        for(int j = 1; j <= i; j++){
            scanf("%d", &triangle[i][j]);
        }
    }

    int mx = 0;
    for(int i = 1; i <= n; i++){
        for(int j = 1; j <= i; j++){
            if(j == 1) dp[i][j] = dp[i-1][j] + triangle[i][j];
            else if(i == j) dp[i][j] = dp[i-1][j-1] + triangle[i][j];
            else dp[i][j] = std::max(dp[i-1][j], dp[i-1][j-1]) + triangle[i][j]; 
            if(mx < dp[i][j]) mx = dp[i][j];
        }
    }

    printf("%d", mx);
}