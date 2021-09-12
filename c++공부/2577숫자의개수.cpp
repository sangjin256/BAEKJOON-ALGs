#include <iostream>

using namespace std;

int main(){
    int result = 1, count[10]{};
    int inputNum;
    for(int i = 0; i < 3; i++){
        cin >> inputNum;
        result *= inputNum;
    }

    while(result != 0){
        count[result % 10]++;
        result /= 10;
    }

    for(int i = 0; i < 10; i++){
        cout << count[i] << "\n";
    }
}