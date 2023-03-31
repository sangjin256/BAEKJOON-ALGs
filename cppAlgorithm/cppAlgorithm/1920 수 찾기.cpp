//
//  1920 수 찾기.cpp
//  cppAlgorithm
//
//  Created by 이상진 on 2023/03/31.
//

#include <iostream>
#include <algorithm>
#include <vector>

using namespace std;

int binarySearch(const vector<int>& arr, int x){
    int s = 0, e = (int)arr.size()-1;
    
    while(s <= e){
        if(arr[(s+e)/2] == x) return 1;
        else if(arr[(s+e)/2] < x) s = (s+e)/2+1;
        else e = (s+e)/2-1;
    }
    return 0;
}

int main(){
    ios_base::sync_with_stdio(false); cout.tie(NULL); cin.tie(NULL);
    
    int n, m, tmp;
    vector<int> arr;
    
    cin >> n;
    
    for(int i = 0; i < n; i++){
        cin >>tmp;
        arr.push_back(tmp);
    }
    
    sort(arr.begin(), arr.end());
    
    cin >> m;
    
    for(int i = 0; i < m; i++){
        cin >> tmp;
        cout << binarySearch(arr, tmp) << "\n";
    }
}
