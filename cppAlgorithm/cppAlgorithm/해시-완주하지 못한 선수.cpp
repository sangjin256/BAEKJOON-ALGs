#include <iostream>
#include <vector>
#include <map>

using namespace std;

string solution(vector<string> participant, vector<string> completion){
    string answer = "";
    map<string, int> compDic;
    
    for(int i = 0; i < completion.size(); i++){
        if(compDic.find(completion[i]) == compDic.end()) compDic.insert({completion[i], 1});
        else compDic[completion[i]]++;
    }
    
    for(int i = 0; i < participant.size(); i++){
        if(compDic.find(participant[i]) == compDic.end()){
            answer = participant[i];
            break;
        }
        else{
            if(compDic[participant[i]] > 0) compDic[participant[i]]--;
            else{
                answer = participant[i];
                break;
            }
        }
    }
    
    return answer;
}

int main(){
    
}
