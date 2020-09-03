#include <bits/stdc++.h>
using namespace std;
int n;
int ability[20][20] = {};
bool chosen[20] = {};
int start = 0, link = 0, mn = INT_MAX;

void search(int y, int count){
    if(count == n/2){
        start = link = 0;
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
                if(chosen[i] && chosen[j]) start += ability[i][j];
                if(!chosen[i] && !chosen[j]) link += ability[i][j];
            }
        }
        mn = min(mn, abs(start-link));
    }
    else{
        for(int i = y; i < n; i++){
            if(chosen[i]) continue;
            chosen[i] = true;
            search(i, count+1);
            chosen[i] = false;
        }
    }
}

int main(){
    scanf("%d", &n);
    for(int i = 0; i < n; i++){
        for(int j = 0; j < n; j++){
            scanf("%d", &ability[i][j]);
        }
    }
    
    search(0, 0);
    
    printf("%d", mn);
}