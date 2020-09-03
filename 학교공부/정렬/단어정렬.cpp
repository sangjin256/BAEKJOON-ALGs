#include <bits/stdc++.h>
using namespace std;

struct comparer{
    bool operator() (const string &a, const string &b) const{
        if(a.length() == b.length()){
            for(int i = 0; i < a.length(); i++){
                if(a[i] != b[i]){
                    return a[i] < b[i];
                }
            }
        }
        return a.length() < b.length();
    }
};

set<string, comparer> s;
vector<string> v;
int main(){
    int n;
    cin >> n;
    for(int i = 0; i < n; i++){
        string a;
        cin >> a;
        s.insert(a);
    }

    for(const string& str : s){
        cout << str <<"\n";
    }
}