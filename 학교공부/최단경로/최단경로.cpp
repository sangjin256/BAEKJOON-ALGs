#include <bits/stdc++.h>
using namespace std;

#define INF INT_MAX;

vector<pair<int,int>> adj[20001];
int n, dist[20001] = {};
priority_queue<pair<int,int>> q;
bool processed[20001] = {};

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

int main(){
    int m, start;
    scanf("%d %d", &n, &m);
    scanf("%d", &start);
    for(int i = 0; i < m; i++){
        int a, b, c;
        scanf("%d %d %d", &a, &b, &c);
        adj[a].push_back({b,c});
    }

    for(int i = 1; i <= n; i++){
        dist[i] = INF;
    }

    dijkstra(start);

    for(int i = 1; i <= n; i++){
        if(dist[i] == INT_MAX){
            printf("INF\n");
            continue;
        }
        printf("%d\n", dist[i]);
    }
}