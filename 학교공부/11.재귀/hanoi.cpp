#include <bits/stdc++.h>

using namespace std;

vector<pair<int,int>> v;
int counter = 0;

void hanoi(int n, int a, int b){
    if(n > 1) hanoi(n-1, a, 6-a-b);
    v.push_back({a,b});
    counter++;
    if(n > 1) hanoi(n-1, 6-a-b, b);
}

int main(){
    int n;
    scanf("%d", &n);
    hanoi(n, 1, 3);
    printf("%d\n", counter);
    for(auto p : v){
        printf("%d %d\n", p.first, p.second);
    }
}