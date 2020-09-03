#include <bits/stdc++.h>
using namespace std;
vector<tuple<int,int,long long>> edges;
bool processed[501] = {};
long long dist[501] = {};
const long long INF = (long long)2 * 500 * 6000 * 10000 + 1;

void bellman(int s, const int& n){
    bool changed = true;
    dist[s] = 0;
    for(int i = 1; i <= n; i++){
        if(changed == false) break;
        changed = false;
        for(const auto& e : edges){
            int a, b, w;
            tie(a, b, w) = e;
            if(dist[b] > dist[a]+w){
                if(dist[a] == INF) continue;
                dist[b] = dist[a]+w;
                changed = true;
            }
        }
        //마지막 라운드에도 바뀌면 시간 무한히 되돌리기 가능
        if(changed && i == n){
            printf("%d", -1);
            return;
        }
    }

    for(int i = 2; i <= n; i++){
        if(dist[i] == INF) printf("%d\n", -1);
        else printf("%lld\n", dist[i]);
    }
}

int main(){
    int n, m;
    scanf("%d %d", &n, &m);
    for(int i = 0; i < m; i++){
        int a, b;
        long long w;
        scanf("%d %d %lld", &a, &b, &w);
        edges.push_back({a,b,w});
    }
    for(int i = 1; i <= n; i++){
        dist[i] = INF;
    }
    
    bellman(1, n);
}