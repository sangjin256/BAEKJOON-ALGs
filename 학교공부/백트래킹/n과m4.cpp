#include <bits/stdc++.h>
using namespace std;
int n, m;
vector<int> permutation;
void search(){
    if(permutation.size() == m+1){
        for(int i = 1; i <= m; i++){
            printf("%d ", permutation[i]);
        }
        printf("\n");
    }
    else{
        for(int i = 1; i <= n; i++){
            if(permutation.back() > i) continue;
            permutation.push_back(i);
            search();
            permutation.pop_back();
        }
    }
}

int main(){
    scanf("%d %d", &n, &m);
    permutation.push_back(0);
    search();
}