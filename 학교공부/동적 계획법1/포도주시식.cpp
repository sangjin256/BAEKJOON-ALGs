#include <iostream>

int main(){
    int n;
    scanf("%d", &n);
    int podo[n+1], dp[n+1];

    for(int i = 1; i <= n; i++){
        scanf("%d", &podo[i]);
    }

    dp[0] = 0;
    dp[1] = podo[1];
    dp[2] = podo[1] + podo[2];
    for(int i = 3; i <= n; i++){
        //i번째의 포도주를 안마시는게 최선일 수도 있으므로 총 3가지로 나눈다.)
        dp[i] = std::max(dp[i-2] + podo[i], std::max(podo[i-1] + dp[i-3] + podo[i], dp[i-1]));
    }

    printf("%d", dp[n]);
}