#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int main(){
    // 배낭 용량, 물건 개수
    int C, n;
    // 물건의 무게와 가치
    vector<pair<int,int>> v;

    cin >> C >> n;

    for(int i = 0; i < n; i++){
        int w, val;
        cin >> w >> val;
        v.push_back({w, val});
    }

    int result[n+1][C+1] = {};

    for(int i = 1; i <= n; i++){
        for(int w = 1; w <= C; w++){
            if(w - v[i-1].first < 0){
                result[i][w] = result[i-1][w];
            }
            else{
                result[i][w] = max(result[i-1][w-v[i-1].first] + v[i-1].second, result[i-1][w]);
            }
        }
    }

    cout << result[n][C] << endl;
}