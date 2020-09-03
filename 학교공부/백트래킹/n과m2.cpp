#include <bits/stdc++.h>
using namespace std;
int n, m;
bool chosen[9] = {};
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
            // 여기서 permutation.back()함수를 호출하기 위해 main함수에서 미리 0을 넣어주었다.
            if(chosen[i] || permutation.back() > i) continue;
            chosen[i] = true;
            permutation.push_back(i);
            search();
            chosen[i] = false;
            permutation.pop_back();
        }
    }
}

int main(){
    scanf("%d %d", &n, &m);
    permutation.push_back(0);
    search();
}