#include <iostream>
#include <string>

using namespace std;

int main(){
    int N, count = 0, sum = 0;
    string str;
    cin >> N;
    for(int i = 0; i < N; i++){
        cin >> str;
        for(int i = 0; i < str.size(); i++){
            if(str[i] == 'O') count++;
            else count = 0;
            sum += count;
        }
        cout << sum << "\n";
        count = 0; sum = 0;
    }
}