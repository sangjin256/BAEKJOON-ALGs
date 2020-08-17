#include <iostream>

bool ready[41] = {true, true,};
int zerone[2][41];

int main(){
    int n;
    scanf("%d", &n);

    zerone[0][0] = zerone[1][1] = true;
    ready[0] = ready[1] = true;
    for(int i = 0; i < n; i++){
        int cas;
        scanf("%d", &cas);
        for(int i = 2; i <= cas; i++){
            if(ready[i]) continue;
            zerone[0][i] = zerone[0][i-1] + zerone[0][i-2];
            zerone[1][i] = zerone[1][i-1] + zerone[1][i-2];
        }
        printf("%d %d\n", zerone[0][cas], zerone[1][cas]);
    }
}