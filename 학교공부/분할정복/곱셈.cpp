#include <iostream>

long long modpow(int x, int n, int m){
    if(n == 1) return 1%m;
    long long u = modpow(x, n/2, m);
    u = u * u % m;
    if(n % 2 == 1) u = u * x % m;
    return u;
}

int main(){
    int x, n, m;
    scanf("%d %d %d", &x, &n, &m);

    printf("%d", modpow(x,n,m));
}