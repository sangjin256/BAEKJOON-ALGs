#include <iostream>

int main(){
    int n, arr[501] = {0}, temp, count2 = 0, count5 = 0;
    std::cin >> n;
    
    for(int i = 2; i <= n; i++){
        if(arr[i] != 0) continue;
        for(int j = i; j <= n; j += i) arr[j] = i;
    }
    
    for(int i = 1; i <= n; i++){
        temp = i;
        while(temp > 1){
            if(arr[temp] == 2) count2++;
            else if(arr[temp] == 5) count5++;
            temp /= arr[temp];
        }
    }
    
    std::cout << (count2 >= count5 ? count5 : count2) << std::endl;
}
