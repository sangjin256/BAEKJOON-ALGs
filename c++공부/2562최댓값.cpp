#include <iostream>
#include <climits>

using namespace std;

int main(){
    int num, index = 0;
    int max = INT_MIN;

    for(int i = 1; i <= 9; i++){
        cin >> num;
        if(num > max){
            max = num;
            index = i;
        }
    }

    cout << max << "\n" << index << endl;
}