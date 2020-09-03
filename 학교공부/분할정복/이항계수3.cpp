// 팩토리얼을 재귀함수로 구현했더니 n이 커지면 함수호출이 너무 많어서 스택오버플로우가 난다.
// 따라서 for문으로 만들었더니 통과했다.
// 함수 호출 갯수를 항상 신경쓰자

#include <iostream>

#define mod 1000000007
long long fac[4000001] = {1,1,};

long long modpow(int x, int n, int m){
    if(n == 0) return 1%m;
    long long u = modpow(x, n/2, m);
    u = u * u % m;
    if(n % 2 == 1) u = u * x % m;
    return u;
}

int main(){
    long long n, k;
    scanf("%lld %lld", &n, &k);
    for(int i = 2; i <= n; i++){
        fac[i] = (i*fac[i-1]) % mod;
    }
    printf("%lld", fac[n] * modpow((fac[k]*fac[n-k]) % mod,mod-2,mod) % mod);
}