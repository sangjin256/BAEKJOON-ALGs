#include <bits/stdc++.h>
using namespace std;
// 1차원은 그 라인, 2차원은 그 라인에 그 숫자가 있는지 여부(0이면 없고 1이면 있음)
int sudoku[9][9] = {};
bool col[9][10] = {}, row[9][10] = {}, block[9][10] = {};
// 0의 위치를 넣을 벡터
vector<pair<int,int>> v;
// 1번 출력이 끝나면 더이상 하지않는다.
bool done = false;

void search(int y, const int& n){
    if(y == n){
        if(done) return;
        for(int i = 0; i < 9; i++){
            for(int j = 0; j < 9; j++){
                printf("%d ", sudoku[i][j]);
            }
            printf("\n");
        }
        done = true;
    }
    else{
        int i = v[y].first;
        int j = v[y].second;
        for(int num = 1; num <= 9; num++){
            if(row[i][num] || col[j][num] || block[(i/3)*3+(j/3)][num]) continue;
            row[i][num] = col[j][num] = block[(i/3)*3+(j/3)][num] = true;
            sudoku[i][j] = num;
            search(y+1, n);
            row[i][num] = col[j][num] = block[(i/3)*3+(j/3)][num] = false;
            sudoku[i][j] = 0;
        }
    }
}

int main(){
    for(int i = 0; i < 9; i++){
        for(int j = 0; j < 9; j++){
            scanf("%d", &sudoku[i][j]);
            if(sudoku[i][j] == 0){
                v.push_back({i,j});
                continue;
            }
            block[(i/3)*3+(j/3)][sudoku[i][j]] = true;
            col[j][sudoku[i][j]] = true;
            row[i][sudoku[i][j]] = true;

        }
    }
    
    search(0, v.size());
}