#include <bits/stdc++.h>
using namespace std;

vector<vector<int>> v;
int bluepapers = 0;
int whitepapers = 0;

void quadtree(int rowbegin, int rowend, int colbegin, int colend){
    if(rowbegin == rowend && colbegin == colend){
        v[rowbegin][colbegin] == 1 ? bluepapers++ : whitepapers++;
        return;
    }
    
    int tmp = v[rowbegin][colbegin];
    for(int i = rowbegin; i <= rowend; i++){
        for(int j = colbegin; j <= colend; j++){
            if(v[i][j] != tmp){
                quadtree(rowbegin, (rowbegin+rowend)/2, colbegin, (colbegin+colend)/2);
                quadtree((rowbegin+rowend)/2+1, rowend, colbegin, (colbegin+colend)/2);
                quadtree(rowbegin, (rowbegin+rowend)/2, (colbegin+colend)/2+1, colend);
                quadtree((rowbegin+rowend)/2+1, rowend, (colbegin+colend)/2+1, colend);
                return;
            }
        }
    }
    
    v[rowbegin][colbegin] == 1 ? bluepapers++ : whitepapers++;
    return;
}

int main(){
    int n;
    scanf("%d", &n);
    for(int i = 0; i < n; i++){
        vector<int> tmp;
        for(int j = 0; j < n; j++){
            int num;
            scanf("%d", &num);
            tmp.push_back(num);
        }
        v.push_back(tmp);
    }

    quadtree(0, n-1, 0, n-1);

    printf("%d\n%d\n", whitepapers, bluepapers);
}