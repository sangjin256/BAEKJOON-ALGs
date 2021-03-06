#include <iostream>

namespace Heapsort{
    void swap(int a[], int x, int y){
        int tmp = a[x];
        a[x] = a[y];
        a[y] = tmp;
    }

    void downheap(int a[], int left, int right){
        int tmp = a[left];
        int child, parent;

        for(parent = left; parent < (right + 1) / 2; parent = child){
            int cl = parent*2 + 1;
            int cr = cl + 1;
            child = (cr <= right && a[cr] > a[cl]) ? cr : cl;
            if(tmp >= a[child]) break;
            a[parent] = a[child];
        }
        a[parent] = tmp;
    }

    void heapsort(int a[], int n){
        for(int i = (n-1)/2; i >= 0; i--) downheap(a, i, n-1);

        for(int i = n-1; i >0; i--){
            swap(a, 0, i);
            downheap(a, 0, i-1);
        }
    }
}