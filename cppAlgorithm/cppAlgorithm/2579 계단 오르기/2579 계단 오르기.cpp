//
//  2579 계단 오르기.cpp
//  cppAlgorithm
//
//  Created by 이상진 on 2023/05/24.
//

#include <iostream>

using namespace std;

int main(){
    ios_base::sync_with_stdio(false); cout.tie(NULL); cin.tie(NULL);
    int n;
    int arr[301]{}, dp[301]{};
    
    cin >> n;
    for(int i = 1; i <= n; i++){
        cin >> arr[i];
    }
    
//    // 0번째는 전전전꺼 + 전꺼 + 자신꺼 1번째는 전전꺼 + 자신꺼
//    dp[1][0] = 10; dp[1][1] = 10;
//    dp[2][0] = 30; dp[2][1] = 20;
    dp[1] = arr[1];
    dp[2] = arr[1]+arr[2];
    for(int i = 3; i <= n; i++){
        dp[i] = dp[i-3]+arr[i-1]+arr[i] <= dp[i-2]+arr[i] ? dp[i-2]+arr[i] : dp[i-3]+arr[i-1]+arr[i];
    }
    
    cout << dp[n] << endl;
}
