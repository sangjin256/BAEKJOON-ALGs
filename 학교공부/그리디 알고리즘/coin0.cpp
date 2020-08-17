#include <iostream>

// int minCoins(int n, int k, int arr[]){
//     int counter = 0;
//     for(int i = n-1; i >= 0; i--){
//         while(k - arr[i] >= 0){
//             k -= arr[i];
//             counter++;
//         }
//         if(k == 0) break;
//     }

//     return counter;
// }

// int main(){
//     int n, k;
//     scanf("%d %d", &n, &k);
//     int coins[n];

//     for(int i = 0; i < n; i++){
//         scanf("%d", &coins[i]);
//     }

//     printf("%d", minCoins(n, k, coins));
// }

int n, k, coins[10], c;

int main(){
    scanf("%d %d", &n, &k);
    for(int i = 0; i < n; i++) scanf("%d", &coins[i]);
    for(int i = n-1; i >= 0; i--){
        c += k / coins[i];
        k %= coins[i];
    }
    printf("%d", c);
}