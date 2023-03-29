//
//  10815 숫자 카드.cpp
//  cppAlgorithm
//
//  Created by 이상진 on 2023/03/17.
//

#include <stdio.h>
#include <algorithm>

using namespace std;

int find(const int* arr, int n, int x){
    int s = 0, e = n-1;
    while(s <= e){
        if(arr[(s+e)/2] == x) return 1;
        else if(arr[(s+e)/2] > x) e = (s+e)/2 - 1;
        else s = (s+e)/2 + 1;
    }
    return 0;
}

int main(){
    int n, m, t;
    scanf("%d", &n);
    int* arr = new int[n];
    
    for(int i = 0; i < n; i++){
        scanf("%d", &t);
        arr[i] = t;
    }
    sort(arr, arr+n);
    
    scanf("%d", &m);
    
    for(int i = 0; i < m; i++){
        scanf("%d", &t);
        printf("%d ", find(arr, n, t));
    }
    
    delete [] arr;
    arr = nullptr;
}
