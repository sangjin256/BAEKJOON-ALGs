#include <iostream>
using namespace std;

# define INF 100000000;

int coins[3], value[100];
bool ready[100];

int solve(int x){
    if(x < 0) return INF;
    if(x == 0) return 0;
    if(ready[x]) return value[x];
    int best = INF;
    for(auto c : coins){
        best = min(best, solve(x-c)+1);
    }
    ready[x] = true;
    return value[x] = best;
}

int main(){
    int k;
    scanf("%d %d %d %d", coins[0], coins[1], coins[2], k);
    printf("%d", solve(k));
}