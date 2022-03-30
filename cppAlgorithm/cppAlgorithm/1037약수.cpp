#include <stdio.h>
#include <algorithm>

int main(){
    int n, *arr;
    scanf("%d", &n);
    arr = new int[n];
    
    for(int i = 0; i < n; i++){
        scanf("%d", arr+i);
    }
    
    std::sort(arr, arr+n);
    
    if(n == 1) printf("%d\n", arr[0] * arr[0]);
    else printf("%d\n", arr[0] * arr[n-1]);
    
    delete [] arr;
    arr = nullptr;
}
