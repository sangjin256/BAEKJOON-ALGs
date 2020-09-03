#include <bits/stdc++.h>
using namespace std;
vector<pair<int,int>> adj[2001];
bool processed[2001] = {};
int dist[2001] = {};
priority_queue<pair<int,int>> q;
const int INF = 2000*50000+2;

void init(int n){
    for(int i = 1; i <= n; i++){
        dist[i] = INF;
        processed[i] = false;
        adj[i].clear();
    }
}

void dijkstra(int s){
    dist[s] = 0;
    q.push({0,s});
    while(!q.empty()){
        int a = q.top().second; q.pop();
        if(processed[a]) continue;
        processed[a] = true;
        for(const auto& u : adj[a]){
            int b = u.first, w = u.second;
            if(dist[b] > dist[a]+w){
                dist[b] = dist[a]+w;
                q.push({-dist[b],b});
            }
        }
    }
}

// g와 h 사이에 있는 도로를 지나갔는지 확인해기 위해 도로의 길이를 적을때 g와 h 사이의 도로는 *2+1해주고 나머지는
// 그냥 *2를 해서 이 도로를 지나가면 홀수가 나오게 한다.
int main(){
    int T;
    scanf("%d", &T);
    for(int cases = 0; cases < T; cases++){
        int n, m, t;
        scanf("%d %d %d", &n, &m, &t);
        init(n);

        int s, g, h;
        scanf("%d %d %d", &s, &g, &h);
        for(int i = 0; i < m; i++){
            int a, b, w;
            scanf("%d %d %d", &a, &b, &w);
            if((a == g && b == h) || (a == h && b == g)){
                adj[a].push_back({b,w*2-1});
                adj[b].push_back({a,w*2-1});
                continue;
            }
            adj[a].push_back({b,w*2});
            adj[b].push_back({a,w*2});
        }

        dijkstra(s);

        vector<int> destinations;
        for(int i = 0; i < t; i++){
            int x;
            scanf("%d", &x);
            if(dist[x] % 2 == 1) destinations.push_back(x);
        }

        sort(destinations.begin(), destinations.end());
        
        for(const auto& a : destinations){
            printf("%d ", a);
        }
        printf("\n");
    }
}