#include <iostream>
#include <vector>
#include <stack>

int main(){
    int n, *arr;
    std::stack<int> st;
    std::vector<int> v;
    
    std::cin >> n;
    arr = new int[n];
    
    for(int i = 0; i < n; i++){
        std::cin >> arr[i];
    }
    
    for(int i = n-1; i >= 0; i--){
        int res = -1;
        while(!st.empty() && st.top() <= arr[i]) st.pop();
        
        if(!st.empty()) res = st.top();
        st.push(arr[i]);
        v.push_back(res);
    }
    
    for(int i = n-1; i >= 0; i--){
        printf("%d ", v[i]);
    }
}

