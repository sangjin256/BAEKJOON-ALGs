#include <bits/stdc++.h>
using namespace std;
int n, k, times[100001] = {};
queue<int> q;

void bfs(int s){
    times[s] = 1;
    q.push(s);
    while(!q.empty()){
        int u = q.front(); q.pop();
        if(u == k) return;
        if(u-1 >= 0 && times[u-1] == 0){
            times[u-1] = times[u] + 1;
            q.push(u-1);
        }
        if(u+1 <= 100000 && times[u+1] == 0){
            times[u+1] = times[u] + 1;
            q.push(u+1);
        }
        if(2*u <= 100000 && times[u*2] == 0){
            times[2*u] = times[u] + 1;
            q.push(2*u);
        }
    }
}

int main(){
    scanf("%d %d", &n, &k);
    
    bfs(n);

    printf("%d", times[k]-1);
}