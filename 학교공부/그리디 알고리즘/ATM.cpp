#include <bits/stdc++.h>

using namespace std;

int main(){
    int n;
    scanf("%d", &n);
    int p[n];
    for(int i = 0; i < n; i++){
        scanf("%d", &p[i]);
    }

    sort(p, p+n);

    int sum = p[0];
    for(int i = 1; i < n; i++){
        p[i] = p[i-1] + p[i];
        sum += p[i];
    }

    printf("%d", sum);
}