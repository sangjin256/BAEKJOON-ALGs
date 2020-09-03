#include <iostream>

namespace selectionsort{
    void selectionsort(int a[], int n){
        for(int i = 0; i < n; i++){
            int min = i;
            for(int j = n-1; j > i; j--){
                if(a[j] < a[min]){
                    min = j;
                }
            }
            swap(a, i, min);
        }
    } 

    void swap(int a[], int x, int y){
        int tmp = a[x];
        a[x] = a[y];
        a[y] = tmp;
    }
}