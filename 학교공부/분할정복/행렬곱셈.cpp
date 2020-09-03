#include <iostream>

int main(){
    int n, m;
    scanf("%d %d", &n, &m);
    int first[n][m];
    for(int i = 0; i < n; i++){
        for(int j = 0; j < m; j++){
            scanf("%d", &first[i][j]);
        }
    }
    int k;
    scanf("%d %d", &m, &k);
    int second[m][k];
    for(int i = 0; i < m; i++){
        for(int j = 0; j < k; j++){
            scanf("%d", &second[i][j]);
        }
    }

    int result[n][k];
    for(int i = 0; i < n; i++){
        for(int j = 0; j < k; j++){
            for(int t = 0; t < m; t++){
                result[i][j] += first[i][t] * second[t][j];
            }
        }
    }

    for(int i = 0; i < n; i++){
        for(int j = 0; j < k; j++){
            printf("%d ", result[i][j]);
        }
        printf("\n");
    }
}