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

    sort(v.begin(), v.end(), [](pair<int,int> a, pair<int,int> b){
                                    if(a.second == b.second) return a.first < b.first;
                                    return a.second < b.second;});

    int endtime = 0;
    int counter = 0;
    for(auto t : v){
        if(t.first >= endtime){
            counter++;
            endtime = t.second;
        }
    }

    printf("%d", counter);
}