#include <bits/stdc++.h>
using namespace std;

vector<int> permutation;
bool chosen[8+1] = {};

void search(const int& n, const int& m){
    if(permutation.size() == m){
        for(auto i : permutation){
            printf("%d ", i);
        }
        printf("\n");
    }
    else{
        for(int i = 1; i <= n; i++){
            if(chosen[i]) continue;
            chosen[i] = true;
            permutation.push_back(i);
            search(n, m);
            chosen[i] = false;
            permutation.pop_back();
        }
    }
}

int main(){
    int n, m;
    scanf("%d %d", &n, &m);

    search(n, m);
}