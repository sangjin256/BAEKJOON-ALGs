#include <iostream>

int main(){
    int n;
    scanf("%d", &n);
    int tiles[n+1];
    tiles[1] = 1;
    tiles[2] = 2;
    for(int i = 3; i <= n; i++){
        tiles[i] = tiles[i-1] + tiles[i-2];
        tiles[i] %= 15746;
    }

    printf("%d", tiles[n]);
}