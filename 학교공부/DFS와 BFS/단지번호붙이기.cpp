#include <bits/stdc++.h>
using namespace std;
int n, counter = 0;
int adj[25][25] = {};
bool visited[25][25] = {};
int movement[4][2] = {{0,1},{0,-1},{1,0},{-1,0}};

vector<int> danji;

void dfs(int x, int y){
    if(visited[x][y]) return;
    visited[x][y] = true;
    counter++;
    for(int i = 0; i < 4; i++){
        int nx = x + movement[i][0];
        int ny = y + movement[i][1];
        if(nx >= 0 && ny >= 0 && nx < n && ny < n){
            if(adj[nx][ny] == 1) dfs(nx, ny);
        }
    }

}

int main(){
    scanf("%d", &n);
    for(int i = 0; i < n; i++){
        for(int j = 0; j < n; j++){
            scanf("%1d", &adj[i][j]);
        }
    }

    for(int i = 0; i < n; i++){
        for(int j = 0; j < n; j++){
            if(adj[i][j] == 0 || visited[i][j]) continue;
            dfs(i,j);
            danji.push_back(counter);
            counter = 0;
        }
    }

    sort(danji.begin(), danji.end());

    printf("%d\n", danji.size());
    for(const auto& a : danji){
        printf("%d\n", a);
    }
}