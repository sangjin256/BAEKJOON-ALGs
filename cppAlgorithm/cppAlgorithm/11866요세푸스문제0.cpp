#include <iostream>
#include <queue>
#include <vector>

int main(){
    std::queue<int> q;
    std::vector<int> v;
    int n, k;
    std::cin >> n >> k;
    
    for(int i = 1; i <= n; i++){
        q.push(i);
    }
    
    while(!q.empty()){
        for(int i = 0; i < k-1; i++){
            q.push(q.front()); q.pop();
        }
        v.push_back(q.front()); q.pop();
    }
    
    std::cout << "<";
    for(int i = 0; i < v.size() - 1; i++){
        std::cout << v[i] << ", ";
    }
    std::cout << v[v.size()-1] << ">" << "\n";
}
