#include <bits/stdc++.h>

using namespace std;

int main(){
    int N;
    scanf("%d", &N);

    int C[501][501] = {};
    vector<int> matrix;

    for(int i = 0; i < N; i++){
        int r, c;
        scanf("%d %d", &r, &c);
        if(i == 0) matrix.push_back(r);
        matrix.push_back(c);
    }

    for(int L = 1; L <= N-1; L++){
        for(int i = 1; i <= N-L; i++){
            int j = i + L;
            C[i][j] = INT_MAX;
            for(int k = i; k <= j-1; k++){
                C[i][j] = min(C[i][j], C[i][k] + C[k+1][j] + matrix[i-1] * matrix[k] * matrix[j]);
            }
        }
    }
    
    printf("%d", C[1][N]);
}