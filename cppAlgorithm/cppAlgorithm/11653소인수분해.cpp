#include <stdio.h>

int main(){
    int divideNum = 2, n;
    scanf("%d", &n);
    
    if(n == 1) return 0;
    else{
        while(n != 1){
            while(n%divideNum == 0){
                printf("%d\n", divideNum);
                n /= divideNum;
            }
            divideNum++;
        }
    }
}
