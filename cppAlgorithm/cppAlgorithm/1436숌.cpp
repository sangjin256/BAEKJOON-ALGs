#include <stdio.h>
#include <string>
#include <cmath>

using namespace std;

string formatString(string_view str, int rearCount){
    string temp = "";
    for(size_t i = 0; i < rearCount - str.length(); i++){
        temp += "0";
    }
    
    return temp + string(str);
}

int main(){
    int n, i = 1;
    string six = "666", num = "666", front = "1";
    int rearDigitCount = 0, rearNum = 0;
    
    scanf("%d", &n);
    
    while(1){
        if(i == n) break;
        if(rearDigitCount == 0){
            for(size_t i = front.length()-1; i >= 0; i--){
                if(front[i] != '6') break;
                rearDigitCount++;
            }
            if(rearDigitCount) continue;
            num = front + six;
            front = to_string(stoi(front)+1);
        }
        else{
            if((int)front.length()-rearDigitCount-1 < 0) num = six;
            else num = front.substr(0,front.length()-rearDigitCount) + six;
            num = num + formatString(to_string(rearNum++), rearDigitCount);
            if(rearNum % ((int)pow(10,rearDigitCount)) == 0){
                rearDigitCount = 0;
                rearNum = 0;
                front = to_string(stoi(front)+1);
            }
        }
        i++;
    }
    
    printf("%s\n", num.c_str());
}
