#include <bits/stdc++.h>
using namespace std;

vector<tuple<int, string, int>> v;
int main(){
    int n;
    cin >> n;
    for(int i = 0; i < n; i++){
        int age;
        string name;
        cin >> age >> name;
        v.push_back({age, name, i});
    }

    sort(v.begin(), v.end(), [](const tuple<int, string, int>& a, const tuple<int, string, int>& b){
                                if(get<0>(a) == get<0>(b)){
                                    return get<2>(a) < get<2>(b);
                                }
                                return get<0>(a) < get<0>(b);});

    for(const auto& p : v){
        cout << get<0>(p) << " " << get<1>(p) << "\n";
    }
}

