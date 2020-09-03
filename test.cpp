// #include <iostream>
// using namespace std;

// # define INF 100000000;

// int coins[3], value[100];
// bool ready[100];

// int solve(int x){
//     if(x < 0) return INF;
//     if(x == 0) return 0;
//     if(ready[x]) return value[x];
//     int best = INF;
//     for(auto c : coins){
//         best = min(best, solve(x-c)+1);
//     }
//     ready[x] = true;
//     return value[x] = best;
// }

// int main(){
//     int k;
//     scanf("%d %d %d %d", &coins[0], &coins[1], &coins[2], &k);
//     printf("%d", solve(k));
// }

#include <iostream>
using namespace std;

#define INF 100000000;

int main(){
    int k, coins[3], value[100];
    scanf("%d %d %d %d", &coins[0], &coins[1], &coins[2], &k);

    value[0] = 0;
    for(int i = 1; i <= k; i++){
        value[i] = INF;
        for(auto c : coins){
            if(i-c >= 0){
                value[i] = min(value[i], value[i-c]+1);
            }
        }
    }

    printf("%d", value[k]);
}