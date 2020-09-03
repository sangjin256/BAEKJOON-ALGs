#include <iostream>

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

int main(){
    int n;
    scanf("%d", &n);
    int arr[n];
    for(int i = 0; i < n; i++){
        scanf("%d", &arr[i]);
    }

    quicksort(arr, 0, n-1);

    for(int i = 0; i < n; i++){
        printf("%d\n", arr[i]);
    }
}
