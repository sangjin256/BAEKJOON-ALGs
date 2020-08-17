#include <iostream>
using namespace std;

int main(){
    int n, stairs[301], dp[301];
    scanf("%d", &n);

    for(int i = 1; i <= n; i++){
        scanf("%d", &stairs[i]);
    }

    dp[1] = stairs[1];
    dp[2] = stairs[1] + stairs[2];

    for(int i = 3; i <= n; i++){
        dp[i] = max(dp[i-2], stairs[i-1] + dp[i-3]) + stairs[i];
    }

    printf("%d", dp[n]);
}