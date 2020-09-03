#include <bits/stdc++.h>
using namespace std;
const int INF = 200000001;

vector<pair<int,int>> adj[801];
bool processed[3][801];
int dist[3][801];
priority_queue<pair<int,int>> q;

int dijkstra(int pos, int s){
    dist[pos][s] = 0;
    q.push({0,s});
    while(!q.empty()){
        int a = q.top().second; q.pop();
        if(processed[pos][a]) continue;
        processed[pos][a] = true;
        for(const auto& u : adj[a]){
            int b = u.first, w = u.second;
            if(dist[pos][b] > dist[pos][a] + w){
                dist[pos][b] = dist[pos][a] + w;
                q.push({-dist[pos][b],b});
            }
        }
    }
}

int main(){
    int n, m, v1, v2;
    scanf("%d %d", &n, &m);
    for(int i = 0; i < m; i++){
        int a, b, w;
        scanf("%d %d %d", &a, &b, &w);
        adj[a].push_back({b,w});
        adj[b].push_back({a,w});
    }
    scanf("%d %d", &v1, &v2);

    fill(&dist[0][0], &dist[2][801], INF);
    
    dijkstra(0, 1);
    dijkstra(1, v1);
    dijkstra(2, v2);

    int result = min(dist[0][v1] + dist[1][v2] + dist[2][n], dist[0][v2] + dist[2][v1] + dist[1][n]);
    
    if(result >= INF || result <= 0){
        printf("%d", -1);
        return;
    }

    printf("%d", result);
}