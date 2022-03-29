#include <stdio.h>
#include <utility>
#include <algorithm>

using namespace std;

bool compare(const pair<int,int>& a, const pair<int,int>& b){
    return a.first < b.first;
}

int main(){
    //가장 싼 곳에서 최대한을 산다.
    int n, tmp;
    long long res = 0, *road;
    pair<int,int> *city;
    scanf("%d", &n);
    city = new pair<int,int>[n];
    road = new long long[n-1];
    
    for(int i = 0; i < n-1; i++){
        scanf("%lld", road+i);
    }
    
    for(int i = 0; i < n; i++){
        scanf("%d", &tmp);
        city[i] = make_pair(tmp, i);
    }
    
    // 거리를 누적합으로 바꿔줌
    for(int i = n-3; i >= 0; i--){
        road[i] += road[i+1];
    }
    
    sort(city, city+n, compare);
    
    tmp = n;
    for(int i = 0; i < n; i++){
        if(city[i].second >= n-1 || tmp < city[i].second) continue;
        if(tmp != n) res += city[i].first * (road[city[i].second] - road[tmp]);
        else res += city[i].first * road[city[i].second];
        
        tmp = city[i].second;
    }
    
    printf("%lld", res);
}
