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

public class weqeeq 
{
    //체스판
    static int[,] chess;
    
    static int[] dx = new int[]{-1, -1, 1, 1, -2, -2, 2, 2};
    static int[] dy = new int[]{2, -2, 2, -2, 1, -1, 1, -1};
    
    //배열의 index에는 현재 위치의 좌표가 들어가고 그 좌표의 리스트에는
    //갈수 있는 좌표와 그 좌표에서 갈 수 있는 위치의 개수가 들어간다.
    static List<(int,int,int)>[,] list;

    //체스가 몇*몇인지
    static int n;
    
    public static void Main(string[] args) {
        //5*5체스판으로 가정
        n = 5;

        chess = new int[n,n];

        //시작지점
        int x = 0;
        int y = 0;
        int startx = x;
        int starty = y;

        chess[x,y] = 1;
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++){
            	KnightTour(ref x, ref y);
            }
        }
        
        if(IsClosed(x,y,startx,starty)){
            Console.WriteLine("닫힌 나이트 투어");
        }
        else Console.WriteLine("열린 나이트 투어");

        for(int i = 0; i < chess.GetLength(0); i++){
            for(int j = 0; j < chess.GetLength(0); j++){
                Console.Write(chess[i,j] + " ");
            }
            Console.WriteLine();
        }
    }

    //범위 안에 있으면서 그 자리가 빈자리인지를 확인하는 함수
    static bool Chk(int x, int y){
        return ((x>=0 && y>=0) && (x<n && y<n) && chess[x,y] == 0);
    }

    //갈수 있는 자리의 갯수를 반환하는 함수
    static int GetDegree(int x, int y){
        int count = 0;
        for(int i = 0; i < dx.Length; i++){
            int nx = x + dx[i];
            int ny = y + dy[i];
            if(Chk(nx, ny)){
                count++;
            }
        }
        return count;
    }

    static bool KnightTour(ref int x, ref int y){
        int minIdx = -1;
        int minVal = dx.Length+1;
        int nx, ny;
        int val;

        for(int i = 0; i < dx.Length; i++){
            nx = x + dx[i];
            ny = y + dy[i];
            if((Chk(nx, ny)) && ((val = GetDegree(nx, ny)) < minVal)){
                minIdx = i;
                minVal = val;
            }
        }
        
        //minIdx가 -1 그대로이면 갈수있는 위치가 없는 것이므로 false를 반환
        if(minIdx == -1) return false;

        nx = x + dx[minIdx];
        ny = y + dy[minIdx];

        chess[nx,ny] = chess[x,y] + 1;
        
        //성공했으므로 x,y에 새 위치를 대입해주고 true를 반환한다.
        x = nx;
        y = ny;

        return true;
    }

    //닫힌 나이트 투어인지 확인하는 함수
    //닫힌 나이트 투어는 끝점에서 시작점으로 돌아갈 수 있다.
    //완성된 나이트 투어 배열로 검사해야한다.
    static bool IsClosed(int x, int y, int startx, int starty){
        for(int i = 0; i < dx.Length; i++){
            if(((x+dx[i]) == startx) && ((y+dy[i]) == starty)){
                return true;
            }
        }
        return false;
    }
}