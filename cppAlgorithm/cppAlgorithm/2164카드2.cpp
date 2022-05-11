#include <iostream>
#include <queue>

int main(){
    std::queue<int> st;
    int n;
    
    std::cin >> n;
    for(int i = 1; i <= n; i++){
        st.push(i);
    }
    
    while(st.size() > 1){
        st.pop();
        int tmp = st.front(); st.pop();
        st.push(tmp);
    }
    
    std::cout << st.front() << std::endl;
}
