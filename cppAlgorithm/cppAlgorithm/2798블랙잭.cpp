#include <stdio.h>
#include <algorithm>

int main(){
    int n, m, *cards, res = -1;
    scanf("%d %d", &n, &m);
    cards = new int[n];
    for(int i = 0; i < n; i++){
        scanf("%d", &cards[i]);
    }
    
    for(int i = 0; i < n; i++){
        if(i+1 >= n) break;
        for(int j = i+1; j < n; j++){
            if(j+1 >= n) break;
            for(int k = j+1; k < n; k++){
                if(m-(cards[i]+cards[j]+cards[k]) >= 0 && m-res > m-(cards[i]+cards[j]+cards[k])) res = cards[i]+cards[j]+cards[k];
            }
        }
    }
    
    printf("%d", res);
}
