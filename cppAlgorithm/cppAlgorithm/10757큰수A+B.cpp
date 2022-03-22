#include <stdio.h>
#include <iostream>
#include <string>

int main(){
    int res[10002], i = 0, aSize, bSize, maxSize, x, y, allrim = 0;
    std::string aString, bString;
    
    std::cin >> aString >> bString;
    aSize = aString.length();
    bSize = bString.length();
    maxSize = (aSize >= bSize) ? aSize : bSize;

    
    for(int j = 10001; j >= 0; j--){
        x = 0;
        y = 0;
        if(i < aSize) x = aString[aSize-i-1] - '0';
        if(i < bSize) y = bString[bSize-i-1] - '0';
        if(x+y+allrim >= 10) {
            res[j] = x+y+allrim-10;
            allrim = 1;
        }
        else{
            res[j] = x+y+allrim;
            allrim = 0;
        }
        i++;
        
        if(maxSize <= i) break;
    }
    
    if(allrim != 0){
        res[10001-maxSize] = allrim;
        maxSize++;
    }
    
    for(int i = 10001-(maxSize-1); i <= 10001; i++){
        printf("%d", res[i]);
    }
}
