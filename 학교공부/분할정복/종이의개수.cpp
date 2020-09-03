#include <bits/stdc++.h>
using namespace std;

vector<vector<int>> v;
int minusone = 0;
int zero = 0;
int one = 0;

void quadtree(int rbegin, int rend, int cbegin, int cend){
    int tmp = v[rbegin][cbegin];
    for(int i = rbegin; i <= rend; i++){
        for(int j = cbegin; j <= cend; j++){
            if(v[i][j] != tmp){
                quadtree(rbegin, rbegin+(rend-rbegin)/3, cbegin, cbegin+(cend-cbegin)/3);
                quadtree(rbegin, rbegin+(rend-rbegin)/3, cbegin+(cend-cbegin)/3+1, cend-(cend-cbegin)/3-1);
                quadtree(rbegin, rbegin+(rend-rbegin)/3, cend-(cend-cbegin)/3, cend);
                quadtree(rbegin+(rend-rbegin)/3+1, rend-(rend-rbegin)/3-1, cbegin, cbegin+(cend-cbegin)/3);
                quadtree(rbegin+(rend-rbegin)/3+1, rend-(rend-rbegin)/3-1, cbegin+(cend-cbegin)/3+1, cend-(cend-cbegin)/3-1);
                quadtree(rbegin+(rend-rbegin)/3+1, rend-(rend-rbegin)/3-1, cend-(cend-cbegin)/3, cend);
                quadtree(rend-(rend-rbegin)/3, rend, cbegin, cbegin+(cend-cbegin)/3);
                quadtree(rend-(rend-rbegin)/3, rend, cbegin+(cend-cbegin)/3+1, cend-(cend-cbegin)/3-1);
                quadtree(rend-(rend-rbegin)/3, rend, cend-(cend-cbegin)/3, cend);
                return;
            }
        }
    }

    tmp == 0 ? zero++ : tmp == 1 ? one++ : minusone++;
}

int main(){
    int n;
    scanf("%d", &n);
    for(int i = 0; i < n; i++){
        vector<int> t;
        for(int j = 0; j < n; j++){
            int a;
            scanf("%d", &a);
            t.push_back(a);
        }
        v.push_back(t);
    }

    quadtree(0, n-1, 0, n-1);

    printf("%d\n%d\n%d\n", minusone, zero, one);
}