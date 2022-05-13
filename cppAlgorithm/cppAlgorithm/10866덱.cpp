#include <iostream>
#include <string>

int deq[10000], max = 10000;
int front = 5000, rear = 5000;

void push_front(int x){
    if(front == -1) front = max-1;
    deq[front--] = x;
}

void push_back(int x){
    rear = (rear+1) % max;
    deq[rear] = x;
}

int empty(){
    if(front == rear) return 1;
    return 0;
}

int pop_front(){
    if(empty()) return -1;
    front = (front+1) % max;
    return deq[front];
}

int pop_back(){
    if(empty()) return -1;
    int res = deq[rear];
    if(rear == 0) rear = max-1;
    else rear--;
    return res;
}

int size(){
    return rear - front;
}

int _front(){
    if(empty()) return -1;
    return deq[(front+1)%max];
}

int _back(){
    if(empty()) return -1;
    return deq[rear];
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
        if(cl == "push_front"){
            push_front(x);
        }
        if(cl == "push_back"){
            push_back(x);
        }
        else if(cl == "pop_front"){
            std::cout << pop_front() << "\n";
        }
        else if(cl == "pop_back"){
            std::cout << pop_back() << "\n";
        }
        else if(cl == "size"){
            std::cout << size() << "\n";
        }
        else if(cl == "empty"){
            std::cout << empty() << "\n";
        }
        else if(cl == "front"){
            std::cout << _front() << "\n";
        }
        else if(cl == "back"){
            std::cout << _back() << "\n";
        }
    }
}
