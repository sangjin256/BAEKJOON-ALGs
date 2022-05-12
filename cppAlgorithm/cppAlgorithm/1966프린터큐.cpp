#include <iostream>
#include <queue>
#include <utility>
#include <algorithm>

int main(){
    int T, n, m, tmp, priIndex, x, y, res = 0;
    std::cin >> T;
    
    for(int tcase = 0; tcase < T; tcase++){
        std::cin >> n >> m;
        std::queue<std::pair<int,int>> q;
        int priorities[100] = {0};
        priIndex = 0;
        res = 0;
        
        for(int i = 0; i < n; i++){
            std::cin >> tmp;
            q.push({tmp,i});
            priorities[i] = tmp;
        }
        
        std::sort(priorities, priorities + 100, std::greater<>());
        
        while(1){
            if(q.front().first < priorities[priIndex]){
                q.push(q.front()); q.pop();
            }
            else if(q.front().first == priorities[priIndex]){
                auto[x, y] = q.front(); q.pop();
                res++;
                priIndex++;
                if(y == m) break;
            }
        }
        
        std::cout << res << "\n";
    }
}
