#include <stdio.h>
#include <algorithm>
#include <vector>

int gcd(int a, int b){
    if(b == 0) return a;
    return gcd(b, a%b);
}

int main(){
    int n, *arr, gcdVal = __INT_MAX__;
    std::vector<int> res;
    scanf("%d'", &n);
    arr = new int[n];
    
    for(int i = 0; i < n; i++){
        scanf("%d", arr+i);
    }
    
    std::sort(arr, arr+n);
    
    for(int i = 1; i < n; i++){
        arr[i] -= arr[0];
    }
    
    for(int i = 2; i < n; i++){
        gcdVal = std::min(gcdVal, gcd(arr[1], arr[i]));
        if(gcdVal == 0){
            printf("%d", arr[0]);
            return 1;
        }
    }
    if(n == 2) gcdVal = arr[1];
    
    for(int i = 2; i * i <= gcdVal; i++){
        if(gcdVal % i == 0) res.push_back(i);
    }
    
    int resSize = (int)res.size();
    for(int i = resSize-1; i >= 0; i--){
        if(gcdVal/res[i] != res[i]) res.push_back(gcdVal/res[i]);
    }
    res.push_back(gcdVal);
    
    for(int i = 0; i < res.size(); i++){
        printf("%d ", res[i]);
    }
    
    delete [] arr;
    arr = nullptr;
}
