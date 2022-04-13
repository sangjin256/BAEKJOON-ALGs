#include <iostream>
#include <string>

int main(){
    int T, stCount = 0;
    std::cin >> T;
    std::string para;
    
    for(int tcase = 0; tcase < T; tcase++){
        stCount = 0;
        std::cin >> para;
        for(int i = 0; i < std::size(para); i++){
            if(para[i] == '(') stCount++;
            else stCount--;
            
            if(stCount < 0) break;
        }
        
        std::cout << (stCount == 0 ? "YES" : "NO") << std::endl;
    }
}
