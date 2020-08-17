#include <iostream>

using namespace std;

int main(){
    int n;
    scanf("%d", &n);
    int arr[n], dp[n];
    for(int i = 0; i < n; i++){
        scanf("%d", &arr[i]);
    }

    for(int i = 0; i < n; i++){
        dp[i] = 1;
        for(int j = 0; j < i; j++){
            if(arr[j] < arr[i]) dp[i] = max(dp[j]+1, dp[i]);
        }
    }

    int mx = 0;
    for(int i = 0; i < n; i++){
        mx = max(mx, dp[i]);
    }
    
    printf("%d", mx);
}