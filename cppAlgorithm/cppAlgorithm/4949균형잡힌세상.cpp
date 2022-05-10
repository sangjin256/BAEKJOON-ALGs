#include <iostream>
#include <stack>
#include <string>

int main(){
    std::string str;
    
    while(1){
        std::stack<char> st;
        getline(std::cin, str);
        if(str == ".") break;
        for(int i = 0; i < str.size(); i++){
            if(str[i] == '('){
                st.push('(');
            }
            else if(str[i] == '['){
                st.push('[');
            }
            else if(str[i] == ')'){
                if(!st.empty() && st.top() == '(') st.pop();
                else{
                    st.push(')');
                    break;
                }
            }
            else if(str[i] == ']'){
                if(!st.empty() && st.top() == '[') st.pop();
                else{
                    st.push(']');
                    break;
                }
            }
        }
        if(!st.empty()) std::cout << "no" << std::endl;
        else std::cout << "yes" << std::endl;
    }
}
