#include <stdio.h>

int gcd(int a, int b){
    if(b == 0) return a;
    else return gcd(b, a % b);
}

int main(){
    int a, b, res;
    scanf("%d %d", &a, &b);
    
    res = gcd(a,b);
    
    printf("%d\n%d\n", res, a*b/res);
}
