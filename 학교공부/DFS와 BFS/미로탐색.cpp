#include <bits/stdc++.h>
using namespace std;
int n, m, adj[101][101] = {}, dist[101][101] = {}, movement[4][2] = {{1,0},{-1,0},{0,-1},{0,1}};
bool visited[101][101] = {};
queue<pair<int,int>> q;

void bfs(int x, int y){
    visited[x][y] = true;
    dist[x][y] = 1;
    q.push({x,y});
    while(!q.empty()){
        int i, j;
        tie(i, j) = q.front(); q.pop();
        for(int k = 0; k < 4; k++){
            int nx = i + movement[k][0];
            int ny = j + movement[k][1];
            if(nx >= 0 && ny >= 0 && nx < n && ny < m){
                if(!visited[nx][ny] && adj[nx][ny] == 1){
                    dist[nx][ny] = dist[i][j] + 1;
                    visited[nx][ny] = true;
                    q.push({nx,ny});
                }
            }
        }
    }

}

int main(){
    scanf("%d %d", &n, &m);
    for(int i = 0; i < n; i++){
        for(int j = 0; j < m; j++){
            scanf("%1d", &adj[i][j]);
        }
    }

    bfs(0,0);
    printf("%d", dist[n-1][m-1]);
}