#include <iostream>

namespace Mergesort{
    int buff[1000000];

    void mergesort(int a[], int left, int right){
        if(left < right){
            int i;
            int center = (left + right) / 2;
            int p = 0;
            int j = 0;
            int k = left;

            mergesort(a, left, center);
            mergesort(a, center+1, right);

            for(i = left; i <= center; i++){
                buff[p++] = a[i];
            }

            while(i <= right && j < p){
                a[k++] = (buff[j] <= a[i]) ? buff[j++] : a[i++];
            }

            while(j < p){
                a[k++] = buff[j++];
            }
        }
    }
}