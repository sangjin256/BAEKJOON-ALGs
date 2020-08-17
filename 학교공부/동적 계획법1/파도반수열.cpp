#include <iostream>

bool ready[101];
long long dp[101];

int main(){
    int t;
    scanf("%d", &t);

    for(int i = 0; i < t; i++){
        int ca;
        scanf("%d", &ca);
        dp[1] = dp[2] = dp[3] = 1;
        if(ready[ca]){
            printf("%lld\n", dp[ca]);
            continue;
        }
        for(int i = 4; i <= ca; i++){
            if(ready[i]) continue;
            ready[i] = true;
            dp[i] = dp[i-2] + dp[i-3];
        }
        printf("%lld\n", dp[ca]);
    }
}