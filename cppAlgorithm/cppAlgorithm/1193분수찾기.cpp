#include <iostream>

using namespace std;

int main(){
    int x, addNum = 1, thisNum = 1;
    cin >> x;
    while(1){
        if(x >= thisNum && x < thisNum+addNum) break;
        thisNum += addNum++;
    }
    addNum++;
    
    if(addNum % 2 == 1) cout << x-thisNum+1 << "/" << addNum-(x-thisNum+1) << endl;
    else cout << addNum-(x-thisNum+1) << "/" << x-thisNum+1 << endl;
}
