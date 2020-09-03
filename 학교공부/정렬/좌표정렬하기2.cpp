#include <bits/stdc++.h>
using namespace std;

vector<pair<int,int>> v;

int main(){
    int n;
    scanf("%d", &n);
    for(int i = 0; i < n; i++){
        int a, b;
        scanf("%d %d", &a, &b);
        v.push_back({a,b});
    }

    sort(v.begin(), v.end(), [](const pair<int,int> &a, const pair<int,int> &b){
                                    if(a.second == b.second) return a.first < b.first;
                                    return a.second < b.second;
    });

    for(const auto& p : v){
        printf("%d %d\n", p.first, p.second);
    }
}