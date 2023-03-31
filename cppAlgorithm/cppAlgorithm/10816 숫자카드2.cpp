//
//  10816 숫자카드 2.cpp
//  cppAlgorithm
//
//  Created by 이상진 on 2023/03/30.

#include <iostream>

using namespace std;

int main(){
    ios_base::sync_with_stdio(false); cout.tie(NULL); cin.tie(NULL);
    
    int ADDNUM = 10000000;

    int n, m, input;
    int *map = new int[20000001];
    
    cin >> n;
    
    for(int i = 0; i < n; i++){
        cin >> input;
        map[input+ADDNUM]++;
    }
    
    cin >> m;
    
    for(int i = 0; i < m; i++){
        cin >> input;
        cout << map[input+ADDNUM] << " ";
    }
    cout << "\n";
    
    delete [] map;
    map = nullptr;
}
