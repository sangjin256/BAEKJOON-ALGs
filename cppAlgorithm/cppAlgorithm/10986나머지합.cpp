#include <iostream>

int main(){
    long long n, m, *arr, *dp, res = 0;
    std::cin >> n >> m;
    arr = new long long[n+1];
    dp = new long long[n+1]{0,};
    arr[0] = 0;
    for(int i = 1; i <= n; i++){
        std::cin >> arr[i];
        arr[i] += arr[i-1];
        dp[arr[i]%m]++;
    }
    for(long long i = 0; i <= n; i++){
        res += dp[i] * (dp[i]-1) / 2;
    }
    res += dp[0];
    
    std::cout << res << std::endl;
    
    delete [] arr;
    delete [] dp;
    arr = nullptr;
    dp = nullptr;
}
