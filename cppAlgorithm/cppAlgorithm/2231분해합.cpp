#include <stdio.h>
#include <string>

using namespace std;

int main(){
    int num = 1, cons, n;
    string str;
    scanf("%d", &n);
    
    for(; num <= 1000000; num++){
        if(num >= n){
            printf("0");
            return 0;
        }
        
        str = to_string(num);
        cons = num;
        for(int i = 0; i < str.length(); i++){
            cons += (str[i] - '0');
        }
        
        if(cons == n){
            printf("%d", num);
            return 0;
        }
    }
}
