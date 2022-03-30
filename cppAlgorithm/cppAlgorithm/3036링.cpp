#include <stdio.h>

int gcd(int a, int b){
    if(b == 0) return a;
    return gcd(b, a%b);
}

int main(){
    int n, *arr, res;
    scanf("%d", &n);
    arr = new int[n];
    
    scanf("%d", arr);
    
    for(int i = 1; i < n; i++){
        scanf("%d", arr+i);
        
        res = gcd(arr[0], arr[i]);
        printf("%d/%d\n", arr[0]/res, arr[i]/res);
    }
    
    
    
    delete [] arr;
    arr = nullptr;
}
