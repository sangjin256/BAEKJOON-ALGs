#include <bits/stdc++.h>
using namespace std;
int n, m, adj[1001][1001] = {}, movement[4][2] = {{1,0},{-1,0},{0,1},{0,-1}};
queue<pair<int,int>> q;
bool alldone = true;

void bfs(int x, int y){
    for(int k = 0; k < 4; k++){
        int nx = x + movement[k][0];
        int ny = y + movement[k][1];
        if(nx >= 0 && ny >= 0 && nx < m && ny < n){
            if(adj[nx][ny] == 0){
                adj[nx][ny] = adj[x][y]+1;
                q.push({nx,ny});
            }
        }
    }
}

int main(){
    scanf("%d %d", &n, &m);
    for(int i = 0; i < m; i++){
        for(int j = 0; j < n; j++){
            scanf("%d", &adj[i][j]);
            if(adj[i][j] == 1){
                q.push({i,j});
            }
            else if(adj[i][j] == 0) alldone = false;
        }
    }

    if(alldone){
        printf("%d", 0);
        return 0;
    }

    while(!q.empty()){
        int x, y;
        tie(x, y) = q.front(); q.pop();
        bfs(x,y);
    }
    
    int mx = INT_MIN;
    for(int i = 0; i < m; i++){
        for(int j = 0; j < n; j++){
            if(adj[i][j] == 0){
                printf("%d", -1);
                return 0;
            }
            mx = max(mx, adj[i][j]);
        }
    }

    printf("%d", mx-1);
}