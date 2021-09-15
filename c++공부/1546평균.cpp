#include <iostream>
#include <climits>

using namespace std;

int main(){
    int N;
    cin >> N;

    float* scores = new float[N];
    int max = INT_MIN;
    float average = 0.0;

    for(int i = 0; i < N; i++){
        cin >> scores[i];
        if(max < scores[i]) max = scores[i];
    }

    for(int i = 0; i< N; i++){
        average += scores[i] / max * 100;
    }
    
    delete[] scores;
    scores = nullptr;
    cout << average / N << endl;
}