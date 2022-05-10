#include <stdio.h>
#include <vector>
#include <stack>

int main(){
    int n, num = 1, temp, count = 0, *arr;
    std::vector<char> res;
    scanf("%d", &n);
    std::stack<int> st;
    arr = new int[n];
    
    for(int i = 0; i < n; i++){
        scanf("%d", arr+i);
    }
    
    for(int i = 1; i <= n; i++){
        st.push(i);
        res.push_back('+');
        
        while(!st.empty() && st.top() == arr[count]){
            st.pop();
            res.push_back('-');
            count++;
        }
    }
    
    if(!st.empty()){
        printf("NO");
        return 0;
    }
    for(int i = 0; i < res.size(); i++){
        printf("%c\n", res[i]);
    }
    
    delete [] arr;
    arr = nullptr;
}
