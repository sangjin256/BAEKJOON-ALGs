#include <iostream>

typedef long long LL;

LL fibo[91];

int main(){
    fibo[0] = 0;
    fibo[1] = 1;

    int n;
    scanf("%d", &n);

    for(int i = 2; i <= n; i++){
        fibo[i] = fibo[i-1] + fibo[i-2];
    }

    printf("%lld", fibo[n]);
}