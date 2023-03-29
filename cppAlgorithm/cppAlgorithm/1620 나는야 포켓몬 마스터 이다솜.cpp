//
//  1620 나는야 포켓몬 마스터 이다솜.cpp
//  cppAlgorithm
//
//  Created by 이상진 on 2023/03/29.
//

#include <stdio.h>
#include <iostream>
#include <unordered_map>

using namespace std;

int main(){
    int n, m, index;
    char *str;
    char* arr[100001] = {};
    unordered_map<string, int> hashPok;
    
    scanf("%d %d", &n, &m);
    //cin >> n >> m;
    
    for(int i = 1; i <= n; i++){
        str = new 
        scanf("%c", str);
        hashPok.insert({str, i});
        arr[i] = str;
    }
    
    for(int i = 0; i < m; i++){
        cin >> str;
        
        if(isdigit(str[0])){
            index = stoi(str);
            cout << arr[index] << "\n";
        }
        else{
            cout << hashPok[str] << "\n";
        }
    }
}
