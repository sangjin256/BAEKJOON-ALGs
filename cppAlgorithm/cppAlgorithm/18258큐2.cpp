#include <iostream>
#include <string>
int queue[2000000] = {0}, max = 2000000;
int front = -1, rear = -1;

void push(int x){
    queue[++rear % max] = x;
}

int empty(){
    if(front == rear) return 1;
    return 0;
}

int pop(){
    if(empty()) return -1;
    return queue[++front % max];
}

int size(){
    return rear - front;
}

int front_(){
    if(empty()) return -1;
    return queue[(front+1)%max];
}

int back_(){
    if(empty()) return -1;
    return queue[rear];
}

int main(){
    std::ios_base::sync_with_stdio(false);std::cin.tie(NULL);
    
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
            std::cout << pop() << "\n";
        }
        else if(cl == "size"){
            std::cout << size() << "\n";
        }
        else if(cl == "empty"){
            std::cout << empty() << "\n";
        }
        else if(cl == "front"){
            std::cout << front_() << "\n";
        }
        else if(cl == "back"){
            std::cout << back_() << "\n";
        }
    }
}
