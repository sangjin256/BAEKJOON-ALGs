//나이트 투어 : n*n 체스판에서 나이트를 체스의 규칙에 맞게 움직이면서
//모든 칸을 정확히 한 번 방문하는 경로
//시작했던 칸으로 돌아올 수 있는 경우를 닫힌 나이트 투어, 그렇지 않은 경우를 열린 나이트 투어라고 함

//체스판의 각 칸이 노드가 되고, 나이트가 체스의 규칙에 따라 두 칸 사이를 이동할 수
//있는 경우를 간선으로 연결한 그래프를 생각하면, 나이트 투어는 이 그래프의 '해밀턴 경로에 대응
//퇴각검색 알고리즘으로 해결하자

//바른스도르프 규칙(Warnsdorf's rule) : 나이트 투어를 찾기 위한 간단하고 효율적인
//휴리스틱으로, 다음으로 움직일 수 있는 경우가 가장 적은 곳으로 움직이는 것
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class Lecture 
{
    //체스판
    static int[,] chess;
    //나이트가 간 자리의 순서를 표시할 변수
    static int number = 1;

    static int[] dx = new int[]{-1, -1, 1, 1, -2, -2, 2, 2};
    static int[] dy = new int[]{2, -2, 2, -2, 1, -1, 1, -1};
    public static void Main(string[] args) {
        //5*5체스판으로 가정
        chess = new int[5,5];
    }

    public void KnightTour(int x, int y, int count){
        if(count == chess.GetLength(0) * chess.GetLength(0)){
            chess[x,y] = number;
            return;
        }
        for(int i = 1; i <= 2; i++){
            for(int j = 2; j >= 1; j--){
                int nx = x 
            }
    }
}