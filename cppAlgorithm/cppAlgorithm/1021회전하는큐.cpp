#include <iostream>
#include <deque>
#include <algorithm>

int main(){
    int n, m, num, res = 0, index;
    std::deque<int> deq;
    std::cin >> n >> m;
    
    for(int i = 1; i <= n; i++){
        deq.push_back(i);
    }

    for(int i = 0; i < m; i++){
        std::cin >> num;
        
        auto ret = std::find(deq.begin(), deq.end(), num);
        index = ret - deq.begin();
        if(index <= deq.size() / 2){
            while(deq.front() != num){
                deq.push_back(deq.front()); deq.pop_front();
                res++;
            }
        }
        else{
            while(deq.front() != num){
                deq.push_front(deq.back()); deq.pop_back();
                res++;
            }
        }
        deq.pop_front();
    }
    
    std::cout << res << "\n";
    
    // 1 2 3 4 5 6 7 8 9 10
    // 2 9 5
    // 3 4 5 6 7 8 9 10 1
    // 5 6 7 8 9 10 1 3 4
    
    // 7 8 9 10 2 3 4 5
    // 3 4 5 7 8 9 10 2
}
