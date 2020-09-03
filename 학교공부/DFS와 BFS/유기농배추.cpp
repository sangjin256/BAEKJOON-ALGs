#include <bits/stdc++.h>
using namespace std;
int n1, n2, counter = 0, adj[50][50] = {}, movement[4][2] = {{0,1},{0,-1},{1,0},{-1,0}};
bool visited[50][50] = {};

void dfs(int x, int y){
    if(visited[x][y]) return;
    visited[x][y] = true;
    for(int i = 0; i < 4; i++){
        int nx = x + movement[i][0];
        int ny = y + movement[i][1];
        if(nx >= 0 && ny >= 0 && nx < n1 && ny < n2){
            if(adj[nx][ny] == 1) dfs(nx,ny);
        }
    }
}

int main(){
    int k;
    scanf("%d", &k);
    for(int cas = 0; cas < k; cas++){
        int m;
        scanf("%d %d %d", &n1, &n2, &m);
        for(int i = 0; i < m; i++){
            int a, b;
            scanf("%d %d", &a, &b);
            adj[a][b] = 1;
        }
        for(int i = 0; i < n1; i++){
            for(int j = 0; j < n2; j++){
                if(visited[i][j] || adj[i][j] == 0) continue;
                dfs(i,j);
                counter++;
            }
        }

        printf("%d\n", counter);
        counter = 0;
        // 케이스가 여러가지이기때문에 초기화는 필수
        memset(adj, 0, sizeof(adj));
        memset(visited, false, sizeof(visited));
    }
}