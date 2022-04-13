#include <iostream>
#include <string>

int stack[10001], topVal = 0;

void push(int x){
    if(topVal >= std::size(stack)) return;
    stack[topVal++] = x;
}

int pop(){
    if(topVal == 0) return -1;
    return stack[--topVal];
}

int size(){
    return topVal;
}

int empty(){
    if(topVal == 0) return 1;
    return 0;
}

int top(){
    if(topVal == 0) return -1;
    return stack[topVal-1];
}

int main(){
    int T, x;
    std::string cl, cm;
    std::cin >> T;
    std::cin.ignore();
    for(int tcase = 0; tcase < T; tcase++){
        getline(std::cin, cl);
        if(cl.find(' ') != std::string::npos){
            int temp = cl.find(' ');
            x = std::stoi(cl.substr(temp+1));
            cl = cl.substr(0, temp);
        }
        if(cl == "push"){
            push(x);
        }
        else if(cl == "pop"){
            std::cout << pop() << std::endl;
        }
        else if(cl == "size"){
            std::cout << size() << std::endl;
        }
        else if(cl == "empty"){
            std::cout << empty() << std::endl;
        }
        else if(cl == "top"){
            std::cout << top() << std::endl;
        }
    }
}
