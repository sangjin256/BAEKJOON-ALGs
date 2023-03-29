//
//  14425 문자열 집합.cpp
//  cppAlgorithm
//
//  Created by 이상진 on 2023/03/29.
//

#include <iostream>
#include <string>
#include <vector>

using namespace std;

int main(){
    int n, m, result = 0;
    size_t tmp;
    vector<string> S;
    string str;
    
    cin >> n >> m;
    for(int i = 0; i < n; i++){
        cin >> str;
        S.push_back(str);
    }
    
    for(int i = 0; i < m; i++){
        cin >> str;
        
        for(int j = 0; j < n; j++){
            if(!S[j].compare(str)){
                result++;
                break;
            }
        }
    }
    
    cout << result << endl;
}
