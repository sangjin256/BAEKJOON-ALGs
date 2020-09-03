#include <iostream>

namespace Insertionsort{
    void insertionsort(int a[], int n){
        for(int i = 1; i < n; i++){
            int tmp = a[i];
            int j;
            for(j = i; j > 0 && a[j-1] > tmp; j--){
                a[j] = a[j-1];
            }
            a[j] = tmp;
        }
    }
}