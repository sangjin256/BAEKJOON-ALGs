#include <iostream>
#include <algorithm>

void bubbleSort(int* a, int n){
    for(int i = 0; i < n-1; i++){
        for(int j = n-1; j > i; j--){
            if(a[j-1] > a[j]) std::swap(a[j-1], a[j]);
        }
    }
}

void bubbleSortS(int* a, int n){
    int k = 0;
    while(k < n-1){
        int last = n-1;
        for(int j = n-1; j > k; j--){
            if(a[j-1] > a[j]){
                std::swap(a[j-1], a[j]);
                last = j;
            }
        }
        k = last;
    }
}

int main(){
    int N, *arr;
    std::cin >> N;
    arr = new int[N];

    for(int i = 0; i < N; i++){
        std::cin >> arr[i];
    }

    bubbleSortS(arr, N);
    for(int i = 0; i < N; i++){
        std::cout << arr[i] << std::endl;
    }
    
    delete [] arr;
    arr = nullptr;
}