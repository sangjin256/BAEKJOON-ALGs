#include <iostream>
#include <vector>

int main(){
    int n, m, count2 = 0, count5 = 0, temp;
    std::vector<int> arr(__INT_MAX__);
    std::cin >> n >> m;
    
    for(int i = 2; i <= n; i++){
        if(arr[i] != 0) continue;
        for(int j = i; j <= n; j += i) arr[j] = i;
    }
    
    for(int i = n-m; i <= n; i++){
        temp = i;
        while(temp > 1){
            if(arr[temp] == 2) count2++;
            else if(arr[temp] == 5) count5++;
            temp /= arr[temp];
        }
    }
    // 101
    // 100
    for(int i = 1; i <= m; i++){
        temp = i;
        while(temp > 1){
            if(arr[temp] == 2) count2--;
            else if(arr[temp] == 5) count5--;
            temp /= arr[temp];
        }
    }
    
    std::cout << (count2 >= count5 ? count5 : count2) << std::endl;
}
