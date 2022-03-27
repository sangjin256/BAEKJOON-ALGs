#include <stdio.h>
#include <algorithm>

using namespace std;

int main(){
    int n, *arr, *originArr, *order;
    scanf("%d", &n);
    arr = new int[n];
    originArr = new int[n];
    order = new int[n]{};
    
    for(int i = 0; i < n; i++){
        int temp;
        scanf("%d", &temp);
        *(arr+i) = temp;
        *(originArr+i) = temp;
    }
    
    sort(arr, arr+n);
    
    //2 4 -10 4 -9
    //-10 -9 2 4 4
    
    // 10 9 10 9 10 9
    // 9 9 9 10 10 10
    
    for(int i = 1; i < n; i++){
        if(arr[i] != arr[i-1]) order[i] = order[i-1]+1;
        else order[i] = order[i-1];
    }
    
    
    
    for(int i = 0; i < n; i++){
        int k = 0;
        for(int j = n/2; j >= 1; j/=2){
            while(k+j < n && arr[k+j] <= originArr[i]) k += j;
        }
        if(arr[k] == originArr[i]) printf("%d ", order[k]);
    }
}
