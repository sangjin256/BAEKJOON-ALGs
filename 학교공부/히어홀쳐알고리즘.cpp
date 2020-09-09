#include <bits/stdc++.h>
using namespace std;
vector<int> adj[8];
vector<int> results[8];
int degree[8] = {};
bool reached = false;

void adjPush(int a, int b){
    adj[a].push_back(b);
    adj[b].push_back(a);
}

bool checkResult(int s, int u){
    if(find(results[u].begin(), results[u].end(), s) != results[u].end() || find(results[s].begin(), results[s].end(), u) != results[s].end()) return true;
    return false;
}

void dfs(int s, int x){
    for(const auto& u : adj[s]){
        if(reached) return;
        //find 함수는 찾는값이 없을 경우 end()값을 반환한다.
        if(checkResult(s, u)){
            continue;
        }else{
            if(u == x){
                results[s].push_back(u);
                degree[s]++; degree[u]++;
                reached = true;
                return;
            }
        }
        results[s].push_back(u);
        degree[s]++; degree[u]++;
        dfs(u,x);
    }
}
         
int main(){
    adjPush(1,2);
    adjPush(1,3);
    adjPush(2,3);
    adjPush(2,5);
    adjPush(2,6);
    adjPush(3,4);
    adjPush(3,6);
    adjPush(4,7);
    adjPush(5,6);
    adjPush(6,7);

    for(int i = 1; i <= 7; i++){
        //회로에 포함되지 않은 진출 간선이 있다면 dfs를 실행한다.
        if(adj[i].size() != degree[i]){
            reached = false;
            dfs(i, i);
        }
    }

    for(int i = 1 ; i <= 7; i++){
        for(const auto& u : results[i]){
            cout << i << " : " << u << "\n";
        }
    }
}