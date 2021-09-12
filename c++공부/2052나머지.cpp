#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main(){
    vector<int> remainders;
    int input, remainder;

    for(int i = 0; i < 10; i++){
        cin >> input;
        remainder = input % 42;
        if(find(remainders.begin(), remainders.end(), remainder) == remainders.end()) remainders.push_back(remainder);
    }

    cout << remainders.size() << endl;
}