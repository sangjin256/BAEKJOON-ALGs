#include <bits/stdc++.h>
using namespace std;
int mx = INT_MIN;
int mn = INT_MAX;
vector<char> operators;
vector<int> numbers;
bool chosen[100] = {};
int result = 0;

// 2번째 매개변수는 숫자의 개수
void search(int y, const int& n){
    if(y == n){
        mn = min(mn, result);
        mx = max(mx, result);
    }
    else{
        for(int i = 0; i < n-1; i++){
            if(chosen[i]) continue;
            int resultbefore = result;
            chosen[i] = true;
            
            char oper = operators[i];
            if(oper == '+'){
                result += numbers[y];
            }
            else if(oper == '-'){
                result -= numbers[y];
            }
            else if(oper == '*'){
                result *= numbers[y];
            }
            else{
                result /= numbers[y];
            }

            search(y+1, n);
            result = resultbefore;
            chosen[i] = false;
        }
    }
}

int main(){
    int n;
    scanf("%d", &n);
    for(int i = 0; i < n; i++){
        int a;
        scanf("%d", &a);
        numbers.push_back(a);
    }
    for(int i = 0; i < 4; i++){
        int a;
        scanf("%d", &a);
        while(a != 0){
            if(i == 0) operators.push_back('+');
            else if(i == 1) operators.push_back('-');
            else if(i == 2) operators.push_back('*');
            else operators.push_back('/');
            a--;
        }
    }

    result = numbers[0];
    search(1, n);

    printf("%d\n%d", mx, mn);
}