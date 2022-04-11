#include <stdio.h>
#include <algorithm>

int main(){
    int n, k, **arr;
    scanf("%d %d", &n, &k);
    arr = new int*[n+1];
    for(int i = 0; i <= n; i++){
        arr[i] = new int[k+1];
    }
    
    for(int i = 1; i <= n; i++){
        for(int j = 0; j <= k; j++){
            if(j == 0 || i == j){
                arr[i][j] = 1;
                continue;
            }
            arr[i][j] = arr[i-1][j-1] + arr[i-1][j];
            arr[i][j] %= 10007;
        }
    }
    
    printf("%d", arr[n][k]);
    
    for(int i = 0; i < n; i++){
        delete [] arr[i];
    }
    delete [] arr;
}

// n k
// n-1 k-1 n-1 k

//                        5 2
//            4 1                       4 2
//       3 0       3 1             3 1         3 2
//             2 0     2 1      2 0   2 1 2  1      2 2
