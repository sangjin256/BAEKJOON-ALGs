#include <iostream>
using namespace std;

int main(){
    int n;
    scanf("%d", &n);
    //lengthf는 앞에서부터 시작, lengthb는 뒤에서부터 시작
    int arr[n], lengthf[n], lengthb[n], result[n];
    for(int i = 0; i < n; i++){
        scanf("%d", &arr[i]);
    }

    for(int i = 0; i < n; i++){
        lengthf[i] = 1;
        lengthb[n-1-i] = 1;
        for(int j = 0; j < i; j++){
            if(arr[j] < arr[i]) lengthf[i] = max(lengthf[i], lengthf[j] + 1);
        }
        for(int j = n-1; j > n-1-i; j--){
            if(arr[j] < arr[n-1-i]) lengthb[n-1-i] = max(lengthb[n-1-i], lengthb[j] + 1);
        }
    }

    int mx = 0;
    for(int i = 0; i < n; i++){
        result[i] = lengthf[i] + lengthb[i] - 1;
        mx = max(mx, result[i]);
    }

    printf("%d", mx);
}