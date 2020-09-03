#include <iostream>

namespace Bubblesort{
    void bubblesort(int a[], int n){
        int k = 0;
        while(k < n-1){
            int last = n-1;
            for(int j = n-1; j > k; j--){
                if(a[j-1] > a[j]){
                    swap(a, j-1, j);
                    last = j;
                }
            }
            k = last;
        }
    }

    void swap(int a[], int x, int y){
        int tmp = a[x];
        a[x] = a[y];
        a[y] = tmp;
    }
}