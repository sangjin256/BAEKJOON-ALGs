#include <bits/stdc++.h>
using namespace std;
bool visited[101];
vector<int> adj[101];
int counter = 0;

void dfs(int s){
    if(visited[s]) return;
    visited[s] = true;
    counter++;
    for(const auto& u : adj[s]){
        dfs(u);
    }
}
int main(){
    int n, m;
    scanf("%d", &n);
    scanf("%d", &m);

    for(int i = 0; i < m; i++){
        int a, b;
        scanf("%d %d", &a, &b);
        adj[a].push_back(b);
        adj[b].push_back(a);
    }

    dfs(1);

    printf("%d", counter-1);
}