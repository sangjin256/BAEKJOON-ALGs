//
//  14425 문자열 집합.cpp
//  cppAlgorithm
//
//  Created by 이상진 on 2023/03/29.
//

#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

int main(){
    int n, m, result = 0;
    size_t tmp;
    vector<int> S;
    string str;
    
    hash<string> str_hash;
    
    cin >> n >> m;
    for(int i = 0; i < n; i++){
        cin >> str;
        S.push_back((int)str_hash(str));
    }
    
    for(int i = 0; i < m; i++){
        cin >> str;
        
        
        if(find(S.begin(), S.end(), (int)str_hash(str)) != S.end()) result++;
    }
    
    cout << result << endl;
}
