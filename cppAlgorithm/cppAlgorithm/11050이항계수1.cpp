#include <stdio.h>

int binomialCoefficient(const int n, const int k){
    if(k == 0 || k == n) return 1;
    return binomialCoefficient(n-1, k-1) + binomialCoefficient(n-1, k);
}

int main(){
    int n, k;
    scanf("%d %d", &n, &k);
    
    printf("%d", binomialCoefficient(n, k));
}
