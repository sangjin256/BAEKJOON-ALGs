#include <bits/stdc++.h>

// int fibo(int n){
//     if(n == 0) return 0;
//     if(n == 1) return 1;
//     return fibo(n-1) + fibo(n-2);
// }

//위 함수보다 더 빠름 = 재귀는 시간 느림
int fibo(int n){
    std::queue<int> q;
    q.push(0);
    q.push(1);
    int count = 0;
    while(count < n){
        int a = q.front();q.pop();
        int b = q.front();
        q.push(a+b);
        count++;
    }
    return q.front();
}

int main(){
    int n;
    scanf("%d", &n);
    printf("%d", fibo(n));
}