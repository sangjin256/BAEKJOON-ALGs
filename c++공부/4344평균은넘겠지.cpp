#include <iostream>

using namespace std;

int main(){
    int testNum, N, upCount;
    float average = 0, nums[1000]{};
    cin >> testNum;

    cout << fixed;
    cout.precision(3);
    for(int i = 0; i < testNum; i++){
        cin >> N;
        upCount = 0;
        average = 0;

        for(int i = 0; i < N; i++){
            cin >> nums[i];
            average += nums[i];
        }
        average /= N;
        
        for(int i = 0; i < N; i++){
            if(nums[i] > average) upCount++;
        }
        cout << (static_cast<float>(upCount) / N) * 100 << "%" << "\n";
    }
}