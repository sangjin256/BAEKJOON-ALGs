#include <iostream>
#include <string>
#include <algorithm>

using namespace std;

int main(){
    string from;
    string to;

    cin >> from;
    cin >> to;

    int dp[from.size()][to.size()];

    dp[0][0] = (from[0] != to[0]) ? 1 : 0;
    for(int i = 1; i < from.size(); i++){
        dp[i][0] = dp[i-1][0] + 1;
    }

    for(int i = 1; i < to.size(); i++){
        dp[0][i] = dp[0][i-1] + 1;
    }

    for(int i = 1; i < from.size(); i++){
        for(int j = 1; j < to.size(); j++){
            int cost = 0;
            if(from[i] != to[j]) cost = 1;
            dp[i][j] = min(dp[i-1][j] + 1, dp[i][j-1] + 1);
            dp[i][j] = min(dp[i][j], dp[i-1][j-1] + cost);
        }
    }

    cout << dp[from.size()-1][to.size()-1] << endl;
}