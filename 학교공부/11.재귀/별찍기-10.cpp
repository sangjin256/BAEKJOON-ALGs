#include <iostream>

using namespace std;

char stars[6561][6561];

void init(){
    for(int i = 0; i < 6561; i++){
        for(int j = 0; j < 6561; j++){
            stars[i][j] = ' ';
        }
    }
}

void makeStar(int n, int x, int y){
    if(n == 1){
        stars[x][y] = '*';
        return;
    }

    int div = n / 3;
    for(int i = 0; i < 3; i++){
        for(int j = 0; j < 3; j++){
            if(i == 1 && j == 1) continue;
            makeStar(div, x + div * i, y + div * j);
        }
    }
    
    return;
}

int main(){

    int n;
    scanf("%d", &n);

    init();
    makeStar(n, 0, 0);

    for(int i = 0; i < n; i++){
        for(int j = 0; j < n; j++){
            printf("%c", stars[i][j]);
        }
        printf("\n");
    }
}