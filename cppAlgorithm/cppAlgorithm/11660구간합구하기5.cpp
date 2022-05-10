#include <iostream>

int main(){
    std::ios_base::sync_with_stdio(false);std::cin.tie(NULL);
    int n, m, arr[1025][1025] = {0}, ask[4];
    std::cin >> n >> m;
    
    for(int i = 1; i <= n; i++){
        for(int j = 1; j <= n; j++){
            std::cin >> arr[i][j];
            arr[i][j] += arr[i-1][j] + arr[i][j-1] - arr[i-1][j-1];
        }
    }
    
    for(int i = 0; i < m; i++){
        std::cin >> ask[0] >> ask[1] >> ask[2] >> ask[3];
        std::cout << arr[ask[2]][ask[3]] + arr[ask[0]-1][ask[1]-1] - arr[ask[2]][ask[1]-1] - arr[ask[0]-1][ask[3]] << "\n";
    }
}
