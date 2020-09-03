#include <iostream>

int main(){
    int n, count[10001] = {};
    scanf("%d", &n);

    int tmp, mx = 0;
    for(int i = 0; i < n; i++){
        scanf("%d", &tmp);
        count[tmp]++;
        if(tmp > mx) mx = tmp;
    }

    for(int i = 0; i <= mx; i++){
        while(count[i] != 0){
            printf("%d\n", i);
            count[i]--;
        }
    }
}