#include <bits/stdc++.h>
using namespace std;

vector<string> v;

void quadtree(int rowbegin, int rowend, int colbegin, int colend){
    char tmp = v[rowbegin][colbegin];
    for(int i = rowbegin; i <= rowend; i++){
        for(int j = colbegin; j <= colend; j++){
            if(v[i][j] != tmp){
                cout << "(";
                quadtree(rowbegin, (rowbegin+rowend)/2, colbegin, (colbegin+colend)/2);
                quadtree(rowbegin, (rowbegin+rowend)/2, (colbegin+colend)/2+1, colend);
                quadtree((rowbegin+rowend)/2+1, rowend, colbegin, (colbegin+colend)/2);
                quadtree((rowbegin+rowend)/2+1, rowend, (colbegin+colend)/2+1, colend);
                cout << ")";
                return;
            }
        }
    }
    cout << (tmp == '1') ? 1 : 0;
}

int main(){
    //cin cout 최적화 코드
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);
    cout.tie(NULL);

    int n;
    cin >> n;
    for(int i = 0; i < n; i++){
        string str;
        cin >> str;
        v.push_back(str);
    }
    
    quadtree(0, n-1, 0, n-1);
}