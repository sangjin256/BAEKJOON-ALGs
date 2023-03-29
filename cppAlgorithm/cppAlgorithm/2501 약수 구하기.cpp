//
//  2501 약수 구하기.cpp
//  cppAlgorithm
//
//  Created by 이상진 on 2023/03/15.
//

#include <stdio.h>
#include <vector>
#include <algorithm>

using namespace std;

int main(){
    int n,k;
    vector<int> vec;
    scanf("%d %d", &n, &k);
    
    for(int i = 1; i * i <= n; i++) if(n % i == 0){
        vec.push_back(i);
        if(n/i > i) vec.push_back(n/i);
    }

    sort(vec.begin(), vec.end());
    
    if(vec.size() < k) printf("%d", 0);
    else printf("%d", vec[k-1]);
    
    return 0;
}
