#include <stdio.h>
#include <iostream>
#include <cmath>

int main(){
    double a, b, v;
    int res = 0;
    std::cin >> a >> b >> v;
    
    res = 1 + static_cast<int>(ceil((v-a)/(a-b)));
    printf("%d", res);
}
