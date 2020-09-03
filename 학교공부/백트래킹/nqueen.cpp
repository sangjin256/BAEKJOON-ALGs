#include <bits/stdc++.h>
using namespace std;
//            열 추적       / 추적              \ 추적
int n, col[15] = {}, diag1[30-1] = {}, diag2[30-1] = {};
int counter = 0;

void search(int y){
    if(y == n){
        counter++;
        return;
    }
    for(int x = 0; x < n; x++){
        if(col[x]||diag1[x+y]||diag2[x-y+(n-1)]) continue;
        col[x] = diag1[x+y] = diag2[x-y+(n-1)] = 1;
        search(y+1);
        col[x] = diag1[x+y] = diag2[x-y+(n-1)] = 0;
    }
}
int main(){
    scanf("%d", &n);
    search(0);
    printf("%d", counter);
}