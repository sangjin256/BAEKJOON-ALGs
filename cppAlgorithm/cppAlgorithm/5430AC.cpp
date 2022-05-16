#include <iostream>
#include <deque>
#include <algorithm>
#include <string.h>

int main(){
    int T, n, isReverseState = 0, isError = 0;
    std::string cmd = "", temp = "";
    
    std::cin >> T;
    
    
    for(int tcase = 0; tcase < T; tcase++){
        std::ios_base::sync_with_stdio(false);std::cin.tie(NULL);
        std::deque<int> dq;
        isReverseState = 0;
        isError = 0;
        std::cin >> cmd >> n >> temp;
        
        char *ptr = strtok(const_cast<char*>(temp.c_str())+1, ",]");
        
        while (ptr != NULL)
        {
            dq.push_back(atoi(ptr));
            ptr = strtok(NULL, ",]");
        }
        
        for(int i = 0; i < cmd.size(); i++){
            if(cmd[i] == 'R') isReverseState = !isReverseState;
            if(cmd[i] == 'D'){
                if(dq.empty()){
                    isError = 1;
                    break;
                }
                if(!isReverseState) dq.pop_front();
                else dq.pop_back();
            }
        }
        
        if(isError){
            std::cout << "error" << "\n";
        }
        else{
            std::cout << "[";
            n = dq.size();
            if(dq.empty()){
                std::cout << "]\n";
            }
            else if(isReverseState){
                for(int i = 0; i < n-1; i++){
                    std::cout << dq.back() << ","; dq.pop_back();
                }
                std::cout << dq.back() << "]\n";
            }
            else{
                for(int i = 0; i < n-1; i++){
                    std::cout << dq.front() << ","; dq.pop_front();
                }
                std::cout << dq.front() << "]\n";
            }
        }
    }
}
