#include <iostream>
#include <cmath>

int divideBy2(int x){
    int i = 1, res = 0;
    while(x / (1<<i) != 0){
        res += x / (1<<i);
        i++;
    }
    return res;
}

int divideBy5(int x){
    int i = 1, res = 0;
    while(x / pow(5, i) != 0){
        res += x / pow(5, i);
        i++;
    }
    return res;
}

int main(){
    int n, m, count2 = 0, count5 = 0;
    std::cin >> n >> m;
    
    count2 = divideBy2(n) - divideBy2(m) - divideBy2(n-m);
    count5 = divideBy5(n) - divideBy5(m) - divideBy5(n-m);
    
    std::cout << (count2 >= count5 ? count5 : count2) << std::endl;
}
