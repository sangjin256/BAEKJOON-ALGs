#include <stdio.h>
#include <algorithm>

using namespace std;

//레전드답
//int main(){
//    int n, m,r=1e9;
//    char s[50][51];
//    scanf("%d%d", &n, &m);
//    for (int i = 0; i < n; i++) scanf("%s", s[i]);
//    for (int i = 0; i + 7 < n; i++) {
//        for (int j = 0; j + 7 < m; j++) {
//            int c = 0;
//            for (int k = i; k < i + 8; k++)
//                for (int l = j; l < j + 8; l++)
//                    c += (s[k][l] == 'B') ^ (k + l & 1);
//            r = min({ r,c,64 - c });
//        }
//    }
//    printf("%d", r);
//    return 0;
//}

void colorChange(char** chessBoard, int m, int n, int& minVal, int& val){
    char startColorSet[2] = {'B', 'W'};
    for(int i = 0; i < m; i++){
        for(int j = 0; j < n; j++){
            if(i + 8 <= m && j + 8 <= n){
                for(int colorNum = 0; colorNum < 2; colorNum++){
                    char startColor = startColorSet[colorNum];
                    val = 0;
                    for(int row = i; row < i+8; row++){
                        for(int col = j; col < j+8; col++){
                            if(startColor == 'B'){
                                if((row-i) % 2 == 0){
                                    if((col-j) % 2 == 0){
                                        if(chessBoard[row][col] == 'W') val++;
                                    }
                                    else{
                                        if(chessBoard[row][col] == 'B') val++;
                                    }
                                }
                                else{
                                    if((col-j) % 2 == 0){
                                        if(chessBoard[row][col] == 'B') val++;
                                    }
                                    else{
                                        if(chessBoard[row][col] == 'W') val++;
                                    }
                                }
                            }
                            else{
                                if((row-i) % 2 == 0){
                                    if((col-j) % 2 == 0){
                                        if(chessBoard[row][col] == 'B') val++;
                                    }
                                    else{
                                        if(chessBoard[row][col] == 'W') val++;
                                    }
                                }
                                else{
                                    if((col-j) % 2 == 0){
                                        if(chessBoard[row][col] == 'W') val++;
                                    }
                                    else{
                                        if(chessBoard[row][col] == 'B') val++;
                                    }
                                }
                            }
                        }
                    }

                    if(minVal > val) minVal = val;
                }
            }
        }
    }
}

int main(){
    int m, n, minVal = __INT_MAX__, val = 0;
    scanf("%d %d", &m, &n);
    char** chessBoard = new char*[m];
    for(int i = 0; i < m; i++){
        chessBoard[i] = new char[n];
        scanf("%s", chessBoard[i]);
    }

    colorChange(chessBoard, m, n, minVal, val);
    printf("%d", minVal);
}
