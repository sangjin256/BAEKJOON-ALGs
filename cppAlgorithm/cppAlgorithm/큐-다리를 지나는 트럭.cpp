#include <iostream>

using namespace std;

int solution(int n){
    int ans = 0;
    int* arr = new int[n];
    arr[0] = 0;
    arr[1] = 1;
    
    delete [] arr;
    arr = NULL;
    return ans;
}
