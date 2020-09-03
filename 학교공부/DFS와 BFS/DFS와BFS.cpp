#include <bits/stdc++.h>
using namespace std;
vector<int> adj[1001];
bool visited[1001] = {};
bool visited_b[1001] = {};
queue<int> q;

void dfs(int s){
    if(visited[s]) return;
    visited[s] = true;
    printf("%d ", s);
    for(const auto& u : adj[s]){
        dfs(u);
    }
}

void bfs(int x){
    visited_b[x] = true;
    q.push(x);
    while(!q.empty()){
        int s = q.front(); q.pop();
        printf("%d ", s);
        for(const auto& u : adj[s]){
            if(visited_b[u]) continue;
            visited_b[u] = true;
            q.push(u);
        }
    }
}
int main(){
    int n, m, v;
    scanf("%d %d %d", &n, &m, &v);

    for(int i = 0; i < m; i++){
        int a, b;
        scanf("%d %d", &a, &b);
        adj[a].push_back(b);
        adj[b].push_back(a);
    }

    // 작은 번호부터 방문해야하므로 정렬해줌
    for(int i = 1; i <= n; i++){
        sort(adj[i].begin(), adj[i].end());
    }

    dfs(v);
    printf("\n");
    bfs(v);
}