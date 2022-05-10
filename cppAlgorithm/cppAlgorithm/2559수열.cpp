#include <iostream>

int main(){
    int n, k, *arr, mx = -__INT_MAX__, res = 0;
    std::cin >> n >> k;
    arr = new int[n];
    
    for(int i = 0; i < n; i++){
        std::cin >> arr[i];
    }
    
    for(int i = 0; i < k-1; i++){
        res += arr[i];
    }
    
    for(int i = k-1; i < n; i++){
        res += arr[i];
        if(mx < res) mx = res;
        res -= arr[i-k+1];
    }
    
    std::cout << mx;
    
    delete [] arr;
    arr = nullptr;
}
