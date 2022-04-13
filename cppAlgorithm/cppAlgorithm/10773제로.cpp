#include <iostream>
#include <stack>

int main(){
    int K, num, res = 0;
    std::stack<int> st;
    std::cin >> K;
    for(int tcase = 0; tcase < K; tcase++){
        std::cin >> num;
        if(!num) st.pop();
        else st.push(num);
    }
    
    while(!st.empty()){
        res += st.top(); st.pop();
    }
    
    std::cout << res << std::endl;
}
