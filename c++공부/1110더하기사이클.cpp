#include <iostream>
#include <string>

using namespace std;

int main(){
    int num, count = 0;
    cin >> num;
    
    string str = to_string(num);
    string lhs(str);
    string rhs(str);
    while(1){
        if(lhs.size() == 1) lhs = "0" + lhs;
        rhs = to_string(static_cast<int>(lhs[0] - '0') + static_cast<int>(lhs[1] - '0'));
        lhs = to_string(static_cast<int>(lhs[1] - '0')) + to_string(static_cast<int>(rhs[rhs.size() - 1]- '0'));
        count++;
        if(stoi(lhs) == num) break;
    }

    cout << count << endl;
}