#include <stdio.h>
#include <utility>

using namespace std;

int main(){
    int n, x, y, order = 1;
    pair<int, int> thisPair;
    pair<int, int>* people;
    scanf("%d", &n);
    
    people = new pair<int, int>[n];
    
    for(int i = 0; i < n; i++){
        scanf("%d %d", &x, &y);
        people[i] = make_pair(x, y);
    }
    
    for(int i = 0; i < n; i++){
        thisPair = people[i];
        order = 1;
        for(int j = 0; j < n; j++){
            if(thisPair == people[j]) continue;
            
            if(thisPair.first < people[j].first && thisPair.second < people[j].second) order++;
        }
        printf("%d ", order);
    }
}
