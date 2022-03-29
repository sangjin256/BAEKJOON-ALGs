#include <stdio.h>
#include <algorithm>

int main(){
    int arr[101][101][101];
    
    std::fill(&arr[0][0][0], &arr[100][100][101], 1);
    
    for(int a = 51; a < 101; a++){
        for(int b = 51; b < 101; b++){
            for(int c = 51; c < 101; c++){
                if(a < b && b < c) arr[a][b][c] = arr[a][b][c-1]+arr[a][b-1][c-1]-arr[a][b-1][c];
                else arr[a][b][c] = arr[a-1][b][c]+arr[a-1][b-1][c]+arr[a-1][b][c-1]-arr[a-1][b-1][c-1];
            }
        }
    }
    
    int a, b, c, x, y, z;
    while(1){
        scanf("%d %d %d", &a, &b, &c);
        if(a == -1 && b == -1 && c == -1) break;
        if(a <= 0 || b <= 0 || c <= 0){
            x = a + 50; y = b + 50; z = c + 50;
        }
        else if(a > 20 || b > 20 || c > 20){
            x = 70; y = 70; z = 70;
        }
        else{
            x = a + 50; y = b + 50; z = c + 50;
        }
        printf("w(%d, %d, %d) = %d\n", a, b, c, arr[x][y][z]);
    }
}
