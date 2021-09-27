#include <iostream>
#include <algorithm>
#include <stack>

int* buff;

void __mergeSort(int* a, int left, int right){
    if(left < right){
        int i, center = (left+right) / 2;
        int p = 0, j = 0, k = left;

        __mergeSort(a, left, center);
        __mergeSort(a, center+1, right);

        for(i = left; i <= center; i++) buff[p++] = a[i];
        while(i <= right && j < p) a[k++] = (buff[j] <= a[i]) ? buff[j++] : a[i++];
        while(j < p) a[k++] = buff[j++];
    }
}

void mergeSort(int* a, int n){
    buff = new int[n];
    __mergeSort(a, 0, n-1);
    delete [] buff;
    buff = nullptr;
}

void quickSort(int* a, int left, int right){
    int pl = left;
    int pr = right;
    int x = a[(pl+pr)/2];

    do{
        while(a[pl] < x) pl++;
        while(a[pr] > x) pr--;
        if(pl <= pr) std::swap(a[pl++], a[pr--]);
    } while(pl <= pr);

    if(left < pr) quickSort(a, left, pr);
    if(pl < right) quickSort(a, pl, right);
}

void quickSortNotRecur(int* a, int left, int right){
    std::stack<int> lstack;
    std::stack<int> rstack;
    lstack.push(left);
    rstack.push(right);

    while(!lstack.empty()){
        int pl = left = lstack.top(); lstack.pop();
        int pr = right = rstack.top(); rstack.pop();
        int x = a[(left+right)/2];

        do{
            while(a[pl] < x) pl++;
            while(a[pr] > x) pr--;
            if(pl <= pr) std::swap(a[pl++], a[pr--]);
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

void downHeap(int* a, int left, int right){
    int tmp = a[left];
    int child, parent;

    for(parent = left; parent < (right+1)/2; parent = child){
        int cl = parent*2+1;
        int cr = cl+1;
        child = (cr <= right && a[cr] > a[cl]) ? cr : cl;
        if(tmp >= a[child]) break;
        a[parent] = a[child];
    }
    a[parent] = tmp;
}

void heapSort(int* a, int n){
    for(int i = (n-1)/2; i >= 0; i--) downHeap(a, i, n-1);

    for(int i = n-1; i > 0; i--){
        std::swap(a[0], a[i]);
        downHeap(a, 0, i-1);
    }
}

int main(){
    int N, *arr;
    std::cin >> N;
    arr = new int[N];

    for(int i = 0; i < N; i++){
        std::cin >> arr[i];
    }

    heapSort(arr, N);

    for(int i = 0; i < N; i++){
        std::cout << arr[i] << "\n";
    }
    
    delete [] arr;
    arr = nullptr;
}