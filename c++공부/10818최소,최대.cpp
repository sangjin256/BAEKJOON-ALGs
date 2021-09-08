#include <iostream>
#include <algorithm>

using namespace std;

int main(){
    int n, input, min = INT_MAX, max = INT_MIN;
    cin >> n;

    for(int i = 0; i < n; i++){
        cin >> input;
        if(input < min) min = input;
        if(input > max) max = input;
    }

    cout << min << " " << max << endl;

    // int* arr = new int[n];
    // for(int i = 0; i < n; i++){
    //     cin >> arr[i];
    // }
    // sort(arr, arr + n);

    // cout << arr[0] << " " << arr[n-1] << endl;
    // delete[] arr;
    // arr = nullptr;
}