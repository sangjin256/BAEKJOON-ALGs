#include <stdio.h>

int main(){
    int T, n, m, arr[30][30] = {0};
    scanf("%d", &T);
    
    for(int i = 1; i < 30; i++){
        for(int j = 0; j < 30; j++){
            if(j == 0 || i == j){
                arr[i][j] = 1;
                continue;
            }
            arr[i][j] = arr[i-1][j-1] + arr[i-1][j];
        }
    }
    
    for(int tcase = 0; tcase < T; tcase++){
        scanf("%d %d", &n, &m);
        printf("%d\n", arr[m][n]);
    }
}
