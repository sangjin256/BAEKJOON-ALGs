#include <bits/stdc++.h>
using namespace std;

int n, m;
vector<int> permutation;

void search(){
    if(permutation.size() == m){
        for(auto i : permutation){
            printf("%d ", i);
        }
        printf("\n");
    }
    else{
        for(int i = 1; i <= n; i++){
            permutation.push_back(i);
            search();
            permutation.pop_back();
        }
    }
}

int main(){
    scanf("%d %d", &n, &m);
    search();
}