#include <stdio.h>

int gcd(int a, int b){
    if(b == 0) return a;
    return gcd(b, a%b);
}

int main(){
    int T, a, b, i = 0;
    scanf("%d", &T);
    
    while(i < T){
        scanf("%d %d", &a, &b);
        
        printf("%d\n", a*b/gcd(a,b));
        i++;
    }
}
