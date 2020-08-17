#include <iostream>

using namespace std;

int main(){
    int n;
    scanf("%d", &n);

    string str1 = "";
    string str2 = "";
    // 2번째 줄까지가 반복된다.
    // 1번째 줄
    for(int i = 0; i < n; i++){
        if(i%2 == 0) str1 += "*";
        else str1 += " ";
    }
    // 2번째 줄
    for(int i = 0; i < n; i++){
        if(i%2 == 1) str2 += "*";
        else str2 += " ";
    }
    if(n == 1){
        cout << str1 << "\n";
        return;
    }

    for(int i = 0; i < n; i++){
        cout << str1 + "\n" + str2 << "\n";
    }
}
// #include <stdio.h>
// int n;
// int main()
// {
// 	scanf("%d", &n);
// 	for(int i=0; i<2*n; puts(""),i++)
//         for(int j=0; j<n; j++)
//             printf("%c", (i+j)%2?' ':'*');
// }