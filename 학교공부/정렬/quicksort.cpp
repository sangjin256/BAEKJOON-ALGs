#include <bits/stdc++.h>

namespace Quicksort{
    void swap(int a[], int x, int y){
        int tmp = a[x];
        a[x] = a[y];
        a[y] = tmp;
    }
    
    void quicksort(int a[], int left, int right){
        int pl = left;
        int pr = right;
        int x = a[(pl+pr)/2];

        do{
            while(a[pl] < x) pl++;
            while(a[pr] > x) pr--;
            if(pl <= pr) swap(a, pl++, pr--);
        } while(pl <= pr);

        if(left < pr) quicksort(a, left, pr);
        if(pl < right) quicksort(a, pl, right);
    }
    
    void quicksort_notrecursive(int a[], int left, int right){
        std::stack<int> lstack;
        std::stack<int> rstack;

        lstack.push(left);
        rstack.push(right);

        while(lstack.empty() != true){
            int pl = left = lstack.top();
            lstack.pop();
            int pr = right = rstack.top();
            rstack.pop();
            int x = a[(pl+pr)/2];

            do{
                while(a[pl] < x) pl++;
                while(a[pr] > x) pr--;
                if(pl <= pr) swap(a, pl++, pr--);
            } while(pl <= pr);

            if(left < pr){
                lstack.push(left);
                rstack.push(pr);
            }

            if(pl < right){
                lstack.push(pl);
                rstack.push(right);
            }
        }
    }
}