#include <bits/stdc++.h>
using namespace std;

int main(){
    int n;
    scanf("%d", &n);
    pair<int,int> p[n];
    int dp[n];

    for(int i = 0; i < n; i++){
        int a, b;
        scanf("%d %d", &a, &b);
        p[i] = {a,b};
    }

    sort(p, p+n, [](const pair<int,int> &a, const pair<int,int> &b){return a.first < b.first;});

    for(int i = 0; i < n; i++){
        dp[i] = 1;
        for(int j = 0; j < i; j++){
            if(p[i].second > p[j].second){
                dp[i] = max(dp[j]+1, dp[i]);
            }
        }
    }

    int mx = 0;
    for(int i = 0; i < n; i++){
        mx = max(mx, dp[i]);
    }

    printf("%d", n - mx);
}