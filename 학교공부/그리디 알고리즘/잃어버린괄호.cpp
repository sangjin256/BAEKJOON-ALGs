#include <bits/stdc++.h>

using namespace std;

int main(){
    int result = 0;
    string str;
    string tmp = "";
    bool minus = false;

    cin >> str;

    for(int i = 0; i <= str.length(); i++){
        if(str[i] == '-' || str[i] == '+' || str[i] == '\0'){
            if(minus) result -= stoi(tmp);
            else result += stoi(tmp);
            tmp = "";
            if(str[i] == '-') minus = true;
            continue;
        }
        tmp += str[i];
    }

    cout << result << "\n";
}