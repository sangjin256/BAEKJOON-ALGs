#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main(int argc, char** argv)
{
	int test_case;
	int T;
    
	scanf("%d", &T);
    
	for(test_case = 1; test_case <= T; ++test_case)
	{
        int N, K;
        scanf("%d %d", &N, &K);
        int dp[101][1001] = {}; 
        vector<pair<int,int>> wc;

        wc.push_back({0,0});
        for(int i = 1; i <= N; i++){
            int w, c;
            scanf("%d %d", &w, &c);
            wc.push_back({w,c});
        }
        
        for(int i = 1; i <= N; i++){
            for(int w = 0; w <= K; w++){
                if(wc[i].first > w){
                    dp[i][w] = dp[i-1][w];
                } else{
                    dp[i][w] = max(dp[i-1][w-wc[i].first] + wc[i].second, dp[i-1][w]);
                }
            }
        }
		
        cout << "#" + to_string(test_case) + " " << dp[N][K] << "\n";
	}
	return 0;
}