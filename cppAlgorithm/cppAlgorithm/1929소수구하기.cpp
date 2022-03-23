#include <stdio.h>

int main(){
    int eratos[1000001] = {0}, m, n, k = 1;
    scanf("%d %d", &m, &n);
    
    for(int i = 2; i < 1000001; i++){
        if(eratos[i] != 0) continue;
        k = 1;
        while(k*i <= 1000000){
            eratos[k*i] = i;
            k++;
        }
    }
    
    for(int i = m; i <= n; i++){
        if(eratos[i] == i) printf("%d\n", i);
    }
}
